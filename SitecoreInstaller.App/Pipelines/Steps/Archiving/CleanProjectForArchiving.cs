namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
  public class CleanProjectForArchiving : Step<PipelineApplicationEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
    {
      Services.Projects.CleanProjectForArchiving(args.ProjectSettings.ProjectFolder);
    }
  }
}
