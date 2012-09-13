﻿using System;
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
            AddPrecondition<CheckProjectNameIsSet>();
            AddPrecondition<CheckWritePermissionToHostFile>();

            //Init steps
            AddStep<StopApplication>();
            AddStep<DetachDatabases>();
            AddStep<DeleteIisSiteAndAppPool>();
            AddStep<DeleteSiteFromHostFile>();
            AddStep<DeleteProject>();
        }
    }
}
