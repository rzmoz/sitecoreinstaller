namespace SitecoreInstaller.App.Pipelines.Steps.Databases
{
    public class AddUserToSqlServerAsSysAdmin : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            Services.Sql.AddUserAsSysadmin(args.ProjectSettings.Sql);
        }
    }
}
