namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
  public class StartApplication : Step
  {
    protected override void InnerInvoke(object sender, StepEventArgs args)
    {
      Services.IisManagement.StartApplication(Services.ProjectSettings.Iis.Name);
    }
  }
}
