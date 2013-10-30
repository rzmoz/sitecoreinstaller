namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
  public class DeleteIisSiteAndAppPool : Step<PipelineApplicationEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
    {
      Services.IisManagement.DeleteApplication(args.ProjectSettings.Iis.Name);
    }
  }
}
