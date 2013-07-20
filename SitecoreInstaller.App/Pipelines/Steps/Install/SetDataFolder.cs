namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class SetDataFolder : Step<PipelineEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineEventArgs args)
        {
            Services.Website.SetDataFolder(args.ProjectSettings.ProjectFolder.Data, args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.DataFolderConfigFile);
        }
    }
}
