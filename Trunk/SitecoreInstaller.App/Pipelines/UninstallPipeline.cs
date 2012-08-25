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
        }

        protected override void InitPreconditions()
        {
            AddPrecondition(new CheckWritePermissionToHostFile(AppSettings));
        }

        protected override void InitSteps()
        {
            AddStep(new StopApplication(AppSettings));
            AddStep(new DetachDatabases(AppSettings));
            AddStep(new DeleteIisSiteAndAppPool(AppSettings));
            AddStep(new DeleteSiteFromHostFile(AppSettings));
            AddStep(new DeleteRuntimeServices(AppSettings));
            AddStep(new DeleteProject(AppSettings));
        }
    }
}
