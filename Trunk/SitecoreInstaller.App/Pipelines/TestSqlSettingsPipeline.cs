namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.Domain.Pipelines;

    public class TestSqlSettingsPipeline : Pipeline
    {
        public TestSqlSettingsPipeline()
        {
            AddPrecondition<CheckSqlConnection>();
        }
    }
}
