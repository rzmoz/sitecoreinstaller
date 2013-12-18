using SitecoreInstaller.App.Pipelines.Steps.Databases;
using SitecoreInstaller.App.Pipelines.Steps.InitialSetup;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class AutoSetupPipeline : Pipeline<PipelineApplicationEventArgs>
    {
        public AutoSetupPipeline()
        {
            AddStep<TryStartSqlServer>();
            AddStep<AddUserToSqlServerAsSysAdmin>();
            AddStep<EnableMixedAuthenticationMode>();
            AddStep<VerifySqlConnection>();
            AddStep<DetermineLocalBuildLibraryFolder>();
        }
    }
}
