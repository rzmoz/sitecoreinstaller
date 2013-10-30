namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class ConfigureFinishingTasks : Step<PipelineApplicationEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
    {
      Services.Website.ExecutePostInstallSteps(args.ProjectSettings.Iis.Url, args.ProjectSettings.ProjectFolder.Website.Directory);
    }
  }
}
