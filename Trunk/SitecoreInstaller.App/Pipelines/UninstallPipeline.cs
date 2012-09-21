using System;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using System.Collections.Generic;

    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.App.Pipelines.Steps.Install;
    using SitecoreInstaller.App.Pipelines.Steps.Uninstall;

    public class UninstallPipeline : Pipeline
    {
        public UninstallPipeline()
        {
            //Init preconditions
            AddPrecondition<CheckProjectNameIsSet>();
            AddPrecondition<CheckWritePermissionToHostFile>();
            AddPrecondition<CheckProjectExists>();

            //Init steps
            AddStep<UpdateProjectSettings>();
            AddStep<StopApplication>();
            AddStep<DetachDatabases>();
            AddStep<DeleteIisSiteAndAppPool>();
            AddStep<DeleteSiteFromHostFile>();
            AddStep<DeleteProject>();
        }
    }
}
