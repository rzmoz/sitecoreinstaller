using System;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using System.Collections.Generic;

    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.App.Pipelines.Steps.Uninstall;

    public class UninstallPipeline : Pipeline
    {
        public UninstallPipeline()
        {
            //Init preconditions
            AddPrecondition(new CheckProjectNameIsSet());
            AddPrecondition(new CheckWritePermissionToHostFile());

            //Init steps
            AddStep(new StopApplication());
            AddStep(new DetachDatabases());
            AddStep(new DeleteIisSiteAndAppPool());
            AddStep(new DeleteSiteFromHostFile());
            AddStep(new DeleteRuntimeServices());
            AddStep(new DeleteProject());
        }
    }
}
