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

    public class InstallPipeline : Pipeline
    {
        public InstallPipeline()
        {
            //Init preconditions
            AddPrecondition(new CheckProjectNameIsSet());
            AddPrecondition(new CheckSitecore());
            AddPrecondition(new CheckLicense());
            AddPrecondition(new CheckWritePermissionToHostFile());
            AddPrecondition(new CheckProjectDoesNotExixts());

            //Init steps
            AddStep(new CreateProjectFolder());
            AddStep(new CopySitecore());
            AddStep(new CopyLicensefile());
            AddStep(new SetDataFolder());
            AddStep(new CopyModuleFiles());
            AddStep(new SetConnectionStrings());
            AddStep(new AttachDatabases());
            AddStep(new AddSitenameToHostFile());
            AddStep(new CreateIisSiteAndAppPool());
            AddStep(new InstallRuntimeServices());
            AddStep(new InstallPackages());
            AddStep(new ExecutePostInstallSteps());
        }
    }
}
