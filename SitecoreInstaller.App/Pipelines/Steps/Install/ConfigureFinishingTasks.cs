namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class ConfigureFinishingTasks : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      Services.Website.ExecutePostInstallSteps(args.ProjectSettings.Iis.Url, args.ProjectSettings.ProjectFolder.Website.Directory);
    }
  }
}
