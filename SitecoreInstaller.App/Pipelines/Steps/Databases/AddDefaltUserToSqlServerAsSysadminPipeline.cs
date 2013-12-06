using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines.Steps.Databases
{
    public class AddDefaltUserToSqlServerAsSysadminPipeline : Pipeline<PipelineApplicationEventArgs>
    {
        public AddDefaltUserToSqlServerAsSysadminPipeline()
        {
            AddStep<AddUserToSqlServerAsSysAdmin>();
        }
    }
}
