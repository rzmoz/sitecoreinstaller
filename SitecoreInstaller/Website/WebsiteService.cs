using System;
using System.Net;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Rest;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Repeating;
using NLog;
using SitecoreInstaller.PreflightChecks;

namespace SitecoreInstaller.Website
{
    public class WebsiteService : IPreflightCheck
    {
        private const string _dataFolderConfigFormat =
            @"<configuration xmlns:patch=""http://www.sitecore.net/xmlconfig/"">
    <sitecore>
        <sc.variable name=""dataFolder"">
            <patch:attribute name=""value"">{0}</patch:attribute>
        </sc.variable>
    </sitecore>
</configuration>";

        private readonly ILogger _logger;
        private readonly IRestClient _restClient;

        public WebsiteService(IRestClient restClient)
        {
            _restClient = restClient;
            _logger = LogManager.GetLogger(nameof(WebsiteService));
        }

        public async Task<bool> WakeUpSiteAsync(string hostName, TimeSpan? timeout = null)
        {
            var respondedOk = false;
            return await Repeat.Task(async () => respondedOk = await PingSiteAsync(hostName).ConfigureAwait(false))
            .WithOptions(o =>
                {
                    o.Timeout = timeout ?? 1.Minutes();
                    o.RetryDelay = 100.MilliSeconds();
                })
            .UntilAsync(() => respondedOk).ConfigureAwait(false);
        }

        public async Task<bool> PingSiteAsync(string hostName)
        {
            if (hostName == null) throw new ArgumentNullException(nameof(hostName));

            var request = new RestRequest(new Uri(hostName.EnsurePrefix("http://")));
            var response = await _restClient.ExecuteAsync(request).ConfigureAwait(false);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public void PingSiteNoWait(string host)
        {
            Task.Run(async () => await PingSiteAsync(host).ConfigureAwait(false));
        }

        public void InitDataFolderConfig(DeploymentDir deploymentdir)
        {
            var dataFolder = deploymentdir.Website.App_Data.FullName;
            var dataFolderConfig = string.Format(_dataFolderConfigFormat, dataFolder);
            dataFolderConfig.WriteAllText(deploymentdir.Website.App_Config.Include.DataFolderConfig, overwrite: true);
            _logger.Trace($"Datafolder set to: {dataFolder}");
        }

        public void FixReportingDatabaseFileNames(DeploymentDir deploymentDir)
        {
            var analyticsFiles = deploymentDir.Databases.GetFiles("Sitecore.Analytics.*", true);

            foreach (var analyticsFile in analyticsFiles)
            {
                _logger.Trace($"Fixing reporting database filename for: {analyticsFile.FullName}");
                analyticsFile.MoveTo(analyticsFile.Directory.ToFile("Sitecore.Reporting" + analyticsFile.Extension));
            }
        }

        public void InitRuntimeServices(DeploymentDir deploymentdir)
        {
            var runtimeServicesDir = deploymentdir.Website.Temp.RuntimeServices;
            Parallel.Invoke(
                () => WebsiteResources.AdminLogin.WriteAllText(runtimeServicesDir.AdminLogin),
                () => WebsiteResources.DeserializeItems.WriteAllText(runtimeServicesDir.DeserializeItems),
                () => WebsiteResources.InstallPackageService.WriteAllText(runtimeServicesDir.InstallPackageService),
                () => WebsiteResources.InstallPackageStatusService.WriteAllText(runtimeServicesDir.InstallPackageStatusService),
                () => WebsiteResources.PostInstallService.WriteAllText(runtimeServicesDir.PostInstallService),
                () => WebsiteResources.PublishSite.WriteAllText(runtimeServicesDir.PublishSite));

            _logger.Trace($"Runtime services installed to {runtimeServicesDir }");
        }

        public PreflightCheckResult Assert()
        {
            return new PreflightCheckResult();
        }
    }
}
