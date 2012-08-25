using System;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using System.Collections.Generic;

    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.App.Pipelines.Steps.Uninstall;

    public class UninstallPipeline : SitecoreInstallerPipeline
    {
        public UninstallPipeline(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
            //Init preconditions
            AddPrecondition(new CheckProjectNameIsSet(getAppSettings));
            AddPrecondition(new CheckWritePermissionToHostFile(getAppSettings));

            //Init steps
            AddStep(new StopApplication(getAppSettings));
            AddStep(new DetachDatabases(getAppSettings));
            AddStep(new DeleteIisSiteAndAppPool(getAppSettings));
            AddStep(new DeleteSiteFromHostFile(getAppSettings));
            AddStep(new DeleteRuntimeServices(getAppSettings));
            AddStep(new DeleteProject(getAppSettings));
        }
    }
}
