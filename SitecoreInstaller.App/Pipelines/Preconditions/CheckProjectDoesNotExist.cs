namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckProjectDoesNotExist : CheckProjectExists
  {
    public override bool InnerEvaluate(object sender, PipelineEventArgs args)
    {
      if (base.InnerEvaluate(sender, args) == false)
        return true;
      ErrorMessage = string.Format("Project '{0}' already exists.\r\nPlease delete first or choose another project name for this installation.\r\n\r\nLocation: {1}", args.ProjectSettings.ProjectName, args.ProjectSettings.ProjectFolder);
      return false;
    }
  }
}
