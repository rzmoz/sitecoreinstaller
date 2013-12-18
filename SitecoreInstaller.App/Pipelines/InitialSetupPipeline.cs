using SitecoreInstaller.App.Pipelines.Steps.Databases;
using SitecoreInstaller.App.Pipelines.Steps.InitialSetup;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class InitialSetupPipeline : Pipeline<PipelineApplicationEventArgs>
    {
        public InitialSetupPipeline()
        {
            AddStep<AddUserToSqlServerAsSysAdmin>();
            AddStep<EnableMixedAuthenticationMode>();
            AddStep<DetermineLocalBuildLibraryFolder>();
        }
    }
}
