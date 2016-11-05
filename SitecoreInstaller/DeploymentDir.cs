using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Repeating;
using Newtonsoft.Json;
using NLog;
using SitecoreInstaller.BuildLibrary;

namespace SitecoreInstaller
{
    public class DeploymentDir : DirPath
    {
        private readonly ILogger _logger;
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };

        public DeploymentDir(DirPath fullPath) : base(fullPath.FullName)
        {
            _logger = LogManager.GetLogger($"{nameof(DeploymentDir)}:{nameof(Name)}");
        }

        public DirPath Databases => Add(nameof(Databases));
        public WebsiteDir Website => new WebsiteDir(Add(nameof(Website)));
        public FilePath DeploymentInfo => this.ToFile("DeploymentInfo.json");

        public DeploymentInfo LoadDeploymentInfo()
        {
            if (this.Exists() == false)
                return null;

            if (DeploymentInfo.Exists() == false)
                return new DeploymentInfo
                {
                    Name = Name
                };

            var json = DeploymentInfo.ReadAllText();
            return JsonConvert.DeserializeObject<DeploymentInfo>(json);
        }

        public void SaveDeploymentInfo(DeploymentInfo info)
        {
            var infoJson = JsonConvert.SerializeObject(info, _jsonSettings);
            infoJson.WriteAllText(DeploymentInfo, true);
            _logger.Debug($"Deployment info for {Name}:\r\n{infoJson}");
            _logger.Trace($"Deployment info for {Name} saved to {DeploymentInfo}");
        }

        public async Task<bool> DeleteAsync()
        {
            var deleted = await Repeat.Task(() => this.DeleteIfExists())
                .WithOptions(o =>
                {
                    o.RetryDelay = 500.MilliSeconds();
                    o.MaxTries = 10;
                })
                .UntilAsync(() => this.Exists() == false).ConfigureAwait(false);
            if (deleted)
                _logger.Trace($"Deployment dir successfully deleted: {FullName}");
            else
                _logger.Error($"Failed to delete Deployment dir: {FullName}");
            return deleted;
        }

        public void CopyModules(IEnumerable<Module> modules)
        {
            modules = modules.ToList();

            //copy standalone sc modules
            Parallel.ForEach(modules.Where(m => m.Path.IsFolder == false), m =>
            {
                _logger.Debug($"Copying module {m.Name} for {Name}...");
                m.Path.ToFile().CopyTo(Website.App_Data.Packages);
                _logger.Debug($"Module {m.Name} for {Name} copied to {Website.App_Data.Packages.ToFile(m.Name)}");
            });

            foreach (var m in modules.Where(m => m.Path.IsFolder))
            {
                _logger.Debug($"Copying module {m.Name} for {Name}...");
                //TODO: Coply custom module files
                _logger.Debug($"Module {m.Name} for {Name} copied to {Website}");
            }
        }

        public void CopyLicenseFile(License license)
        {
            _logger.Debug($"Copying license file {license.Name} for {Name}...");
            license.Path.ToFile().CopyTo(Website.App_Data.LicenseXml);
            _logger.Debug($"License file for {Name} copied to {Website.App_Data.LicenseXml}");
        }

        public void CopySitecore(BuildLibrary.Sitecore sitecore)
        {
            _logger.Debug($"Copying {sitecore.Name} for {Name}...");
            Parallel.Invoke(() =>
            {
                //copy sitecore
                var target = Website;
                _logger.Debug($"Copying Website for {Name} to {target }");
                sitecore.Website.CopyTo(target, includeSubfolders: true);
                _logger.Trace($"Sitecore copied to {target }");
            }, () =>
            {
                //copy databases
                var target = Databases;
                _logger.Debug($"Copying Databases for {Name} to {target }");
                sitecore.Databases.CopyTo(target, includeSubfolders: true);
                _logger.Trace($"Databases copied to {target }");
            }, () =>
            {
                //copy data
                var target = Website.App_Data;
                _logger.Debug($"Copying Data for {Name} to {target }");
                sitecore.Data.CopyTo(target, includeSubfolders: true);
                _logger.Trace($"Data copied to {target }");
            });

            _logger.Trace($"{sitecore.Name} for {Name} copied");
        }
    }
}
