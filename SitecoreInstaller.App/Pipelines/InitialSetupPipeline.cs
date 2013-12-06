using SitecoreInstaller.App.Pipelines.Steps.Databases;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class InitialSetupPipeline : Pipeline<PipelineApplicationEventArgs>
    {
        public InitialSetupPipeline()
        {
            AddStep<AddUserToSqlServerAsSysAdmin>();
        }
    }
}
