using System;
using System.Linq;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Domain.Database;
using SitecoreInstaller.Domain.Pipelines;
using SitecoreInstaller.Framework.Xml;

namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.App.Pipelines.Steps.Install;

    public class InstallPipeline : SitecoreInstallerPipeline
    {
        public InstallPipeline(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        protected override void InitPreconditions()
        {
            AddPrecondition(new CheckSitecore(AppSettings));
            AddPrecondition(new CheckLicense(AppSettings));
            AddPrecondition(new CheckWritePermissionToHostFile(AppSettings));
            AddPrecondition(new CheckProjectDoesNotExixts(AppSettings));
        }

        protected override void InitSteps()
        {
            AddStep(new CreateProjectFolder(AppSettings));
            AddStep(new CopySitecore(AppSettings));
            AddStep(new CopyLicensefile(AppSettings));
            AddStep(new SetDataFolder(AppSettings));
            AddStep(new CopyModuleFiles(AppSettings));
            AddStep(new SetConnectionStrings(AppSettings));
            AddStep(new AttachDatabases(AppSettings));
            AddStep(new AddSitenameToHostFile(AppSettings));
            AddStep(new CreateIisSiteAndAppPool(AppSettings));
            AddStep(new InstallRuntimeServices(AppSettings));
            AddStep(new InstallPackages(AppSettings));
            AddStep(new ExecutePostInstallSteps(AppSettings));
        }
    }
}
