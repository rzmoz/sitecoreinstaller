namespace SitecoreInstaller.App.Pipelines.Steps.Databases
{
    public class TryStartSqlServer : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            if (Services.Sql.IsStarted())
                return;

            Services.Sql.TryStartDefaultSqlService();
        }
    }
}
