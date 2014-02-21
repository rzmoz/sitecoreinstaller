using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.IO;
using FileTypes = SitecoreInstaller.Framework.IO.FileTypes;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class SetCustomSitecoreSettings : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            var sourceSettingsFiles = args.ProjectSettings.ProjectFolder.GetFiles(FileTypes.ConfigDelta);



            var targetSettingsFile = args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.CustomSitecoreSettingsConfigFile;
        }
    }
}
