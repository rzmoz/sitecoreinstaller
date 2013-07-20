namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckProjectNameIsSet : Precondition
  {

    public override bool InnerEvaluate(object sender, StepEventArgs args)
    {
      if (args.ProjectSettings.ProjectNameIsSet)
        return true;
      ErrorMessage = "Project name not set. Please enter project name";
      return false;
    }
  }
}
