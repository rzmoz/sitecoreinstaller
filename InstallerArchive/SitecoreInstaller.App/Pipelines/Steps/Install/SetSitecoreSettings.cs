using SitecoreInstaller.Framework.IOx;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class SetSitecoreSettings : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            /*
            var sourceSettingsFiles = args.ProjectSettings.ProjectFolder.GetFiles(FileTypes.SitecoreSettings);
            var targetSettingsFile = args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.SitecoreSettingsConfigFile;

            Services.Website.SetSitecoreSettings(args.ProjectSettings.SitecoreSettings, targetSettingsFile);
             * */
        }
    }
}
