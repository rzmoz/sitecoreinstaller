namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckSitecore : Precondition<PipelineApplicationEventArgs>
  {
    public override bool InnerEvaluate(object sender, PipelineApplicationEventArgs args)
    {
      if (args.ProjectSettings.BuildLibrarySelections.SelectedSitecore != null)
        return true;
      ErrorMessage = "You haven't selected a Sitecore. Please add a Sitecore in preferences pane if you have none";
      return false;
    }
  }
}
