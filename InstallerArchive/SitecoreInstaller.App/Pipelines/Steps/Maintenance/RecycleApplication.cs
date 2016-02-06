namespace SitecoreInstaller.App.Pipelines.Steps.Maintenance
{
    public class RecycleApplication : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            Services.IisManagement.RecycleApplication(args.ProjectSettings.Iis.Name);
        }
    }
}
