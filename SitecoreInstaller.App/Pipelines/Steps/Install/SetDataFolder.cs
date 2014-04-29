namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class SetDataFolder : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            Services.WwwRoot.SetDataFolder(args.ProjectSettings.ProjectFolder.Data, args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.DataFolderConfigFile);
        }
    }
}
