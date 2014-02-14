using SitecoreInstaller.App.Pipelines.Steps.AutoSetup;
using SitecoreInstaller.App.Pipelines.Steps.Databases;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class AutoSetupPipeline : Pipeline<PipelineApplicationEventArgs>
    {
        public AutoSetupPipeline()
        {
            AddStep<TryStartSqlServer>();
            AddStep<DetermineSqlConnection>();
            AddStep<AddUserToSqlServerAsSysAdmin>();
            AddStep<EnableMixedAuthenticationMode>();
            AddStep<VerifySqlConnection>();
            AddStep<DetermineLocalBuildLibraryFolder>();
        }
    }
}
