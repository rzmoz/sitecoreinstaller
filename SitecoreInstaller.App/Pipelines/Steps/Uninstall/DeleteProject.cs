namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
  public class DeleteProject : Step<CleanupEventArgs>
  {
    protected override void InnerInvoke(object sender, CleanupEventArgs args)
    {
      //we only delete project if we're deep cleaning
      if (args.DeepClean)
        Services.Projects.DeleteProject(args.ProjectSettings.ProjectFolder.Directory);
    }
  }
}
