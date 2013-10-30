namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckSqlConnection : Precondition<PipelineApplicationEventArgs>
  {
    public override bool InnerEvaluate(object sender, PipelineApplicationEventArgs args)
    {
      if (args.ProjectSettings.Sql.TestConnection())
        return true;
      ErrorMessage = "Sql settings are not properly set. Check under preferences";
      return false;
    }
  }
}
