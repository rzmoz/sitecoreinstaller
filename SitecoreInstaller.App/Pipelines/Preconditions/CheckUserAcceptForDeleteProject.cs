namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckUserAcceptForDeleteProject : Precondition<CleanupEventArgs>
  {
    public override bool InnerEvaluate(object sender, CleanupEventArgs args)
    {
      return args.DeleteProject;
    }
  }
}
