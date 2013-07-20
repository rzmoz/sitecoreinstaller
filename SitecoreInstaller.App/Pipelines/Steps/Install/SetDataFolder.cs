namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class SetDataFolder : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            Services.Website.SetDataFolder(args.ProjectSettings.ProjectFolder.Data, args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.DataFolderConfigFile);
        }
    }
}
