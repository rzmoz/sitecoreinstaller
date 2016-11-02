using System;
using System.Net;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
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

        public WebsiteService()
        {
            _logger = LogManager.GetLogger(nameof(WebsiteService));
        }


        public async Task PingSiteAsync(string host)
        {
            try
            {
                _logger.Debug($"pinging {host}");
                var webRequest = (HttpWebRequest)WebRequest.Create($"http://{host}/");
                webRequest.AllowAutoRedirect = false;
                webRequest.Timeout = (int)1.Minutes().TotalMilliseconds;
                await webRequest.GetResponseAsync().ConfigureAwait(false);
            }
            catch (WebException e)
            {
                _logger.Debug(e.ToString());
            }
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
