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
            //Init preconditions
            AddPrecondition(new CheckProjectNameIsSet(getAppSettings));
            AddPrecondition(new CheckSitecore(getAppSettings));
            AddPrecondition(new CheckLicense(getAppSettings));
            AddPrecondition(new CheckWritePermissionToHostFile(getAppSettings));
            AddPrecondition(new CheckProjectDoesNotExixts(getAppSettings));

            //Init steps
            AddStep(new CreateProjectFolder(getAppSettings));
            AddStep(new CopySitecore(getAppSettings));
            AddStep(new CopyLicensefile(getAppSettings));
            AddStep(new SetDataFolder(getAppSettings));
            AddStep(new CopyModuleFiles(getAppSettings));
            AddStep(new SetConnectionStrings(getAppSettings));
            AddStep(new AttachDatabases(getAppSettings));
            AddStep(new AddSitenameToHostFile(getAppSettings));
            AddStep(new CreateIisSiteAndAppPool(getAppSettings));
            AddStep(new InstallRuntimeServices(getAppSettings));
            AddStep(new InstallPackages(getAppSettings));
            AddStep(new ExecutePostInstallSteps(getAppSettings));
        }
    }
}
