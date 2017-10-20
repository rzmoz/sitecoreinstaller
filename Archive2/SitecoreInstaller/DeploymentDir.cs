using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.NLog;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Repeating;
using Newtonsoft.Json;
using SitecoreInstaller.BuildLibrary;

namespace SitecoreInstaller
{
    public class DeploymentDir : DirPath
    {
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };

        public DeploymentDir(DirPath fullPath) : base(fullPath.FullName)
        {
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
            this.NLog().Debug($"Deployment info for {Name}:\r\n{infoJson}");
            this.NLog().Trace($"Deployment info for {Name} saved to {DeploymentInfo}");
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
                this.NLog().Trace($"Deployment dir successfully deleted: {FullName}");
            else
                this.NLog().Error($"Failed to delete Deployment dir: {FullName}");
            return deleted;
        }

        public void CopyModules(IEnumerable<Module> modules)
        {
            modules = modules.ToList();

            //copy standalone sc modules
            Parallel.ForEach(modules.Where(m => m.Path.IsFolder == false), m =>
            {
                this.NLog().Debug($"Copying module {m.Name} for {Name}...");
                m.Path.ToFile().CopyTo(Website.App_Data.Packages);
                this.NLog().Debug($"Module {m.Name} for {Name} copied to {Website.App_Data.Packages.ToFile(m.Name)}");
            });

            foreach (var m in modules.Where(m => m.Path.IsFolder))
            {
                this.NLog().Debug($"Copying module {m.Name} for {Name}...");
                //TODO: Coply custom module files
                this.NLog().Debug($"Module {m.Name} for {Name} copied to {Website}");
            }
        }

        public void CopyLicenseFile(License license)
        {
            this.NLog().Debug($"Copying license file {license.Name} for {Name}...");
            license.Path.ToFile().CopyTo(Website.App_Data.LicenseXml);
            this.NLog().Debug($"License file for {Name} copied to {Website.App_Data.LicenseXml}");
        }

        public void CopySitecore(BuildLibrary.Sitecore sitecore)
        {
            this.NLog().Debug($"Copying {sitecore.Name} for {Name}...");
            Parallel.Invoke(() =>
            {
                //copy sitecore
                var target = Website;
                this.NLog().Debug($"Copying Website for {Name} to {target }");
                sitecore.Website.CopyTo(target, includeSubfolders: true);
                this.NLog().Trace($"Sitecore copied to {target }");
            }, () =>
            {
                //copy databases
                var target = Databases;
                this.NLog().Debug($"Copying Databases for {Name} to {target }");
                sitecore.Databases.CopyTo(target, includeSubfolders: true);
                this.NLog().Trace($"Databases copied to {target }");
            }, () =>
            {
                //copy data
                var target = Website.App_Data;
                this.NLog().Debug($"Copying Data for {Name} to {target }");
                sitecore.Data.CopyTo(target, includeSubfolders: true);
                this.NLog().Trace($"Data copied to {target }");
            });

            this.NLog().Trace($"{sitecore.Name} for {Name} copied");
        }
    }
}
