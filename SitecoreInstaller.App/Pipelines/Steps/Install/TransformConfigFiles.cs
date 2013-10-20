using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class TransformConfigFiles : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      var deltaFiles = args.ProjectSettings.ProjectFolder.Directory.GetFiles(FileTypes.ConfigDelta);
      var webConfig = args.ProjectSettings.ProjectFolder.Website.CombineTo<FileInfo>("web.config");
      var connectionStrings = args.ProjectSettings.ProjectFolder.Website.AppConfig.CombineTo<FileInfo>("ConnectionStrings.config");

      Services.Website.TransformConfigFiles(deltaFiles, webConfig, connectionStrings);
    }
  }
}
