namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
  public class StartApplication : Step<PipelineApplicationEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
    {
      Services.IisManagement.StartApplication(args.ProjectSettings.Iis.Name);
    }
  }
}
