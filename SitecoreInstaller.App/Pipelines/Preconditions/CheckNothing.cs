namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckNothing : Precondition<PipelineEventArgs>
  {
    public override bool InnerEvaluate(object sender, PipelineEventArgs args)
    {
      return args.ProjectSettings != null;
    }
  }
}
