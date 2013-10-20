namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckSitecore : Precondition<PipelineEventArgs>
  {
    public override bool InnerEvaluate(object sender, PipelineEventArgs args)
    {
      if (args.ProjectSettings.BuildLibrarySelections.SelectedSitecore != null)
        return true;
      ErrorMessage = "You haven't selected a Sitecore. Please add a Sitecore in preferences pane if you have none";
      return false;
    }
  }
}
