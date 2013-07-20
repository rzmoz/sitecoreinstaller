namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
  public class StartApplication : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      Services.IisManagement.StartApplication(args.ProjectSettings.Iis.Name);
    }
  }
}
