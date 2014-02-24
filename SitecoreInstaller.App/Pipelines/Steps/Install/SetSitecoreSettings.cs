using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class SetSitecoreSettings : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            if (args.ProjectSettings.SitecoreSettings == null)
                return;

            var sourceSettingsFiles = args.ProjectSettings.ProjectFolder.GetFiles(FileTypes.ConfigDelta);
            var targetSettingsFile = args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.SitecoreSettingsConfigFile;

            Services.Website.SetSitecoreSettings(args.ProjectSettings.SitecoreSettings, targetSettingsFile);
        }
    }
}
