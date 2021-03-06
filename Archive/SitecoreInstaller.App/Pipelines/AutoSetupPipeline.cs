﻿using SitecoreInstaller.App.Pipelines.Steps.AutoSetup;
using SitecoreInstaller.App.Pipelines.Steps.Databases;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class AutoSetupPipeline : Pipeline<PipelineApplicationEventArgs>
    {
        public AutoSetupPipeline()
        {
            AddStep<DetermineSqlConnection>();
            AddStep<TryStartSqlServer>();
            AddStep<DetermineSqlConnection>();
            AddStep<SaveSqlInstanceNameToPreferences>();
            AddStep<AddUserToSqlServerAsSysAdmin>();
            AddStep<EnableMixedAuthenticationMode>();
            AddStep<VerifySqlConnection>();
            AddStep<DetermineLocalBuildLibraryFolder>();
        }
    }
}
