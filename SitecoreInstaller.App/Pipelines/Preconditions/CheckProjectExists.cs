namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  using System.IO;

  public class CheckProjectExists : Precondition<PipelineEventArgs>
  {
    public override bool InnerEvaluate(object sender, PipelineEventArgs args)
    {
      if (Directory.Exists(args.ProjectSettings.ProjectFolder.FullName))
        return true;

      ErrorMessage = string.Format("Project '{0}' doesn't exist.\r\n\r\nLocation: {1}", args.ProjectSettings.ProjectName, args.ProjectSettings.ProjectFolder);
      return false;
    }
  }
}
