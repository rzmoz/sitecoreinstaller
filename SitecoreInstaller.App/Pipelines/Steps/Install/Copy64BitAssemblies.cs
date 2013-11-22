using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class Copy64BitAssemblies : Step<PipelineApplicationEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
    {
      var bin32BitFolder = args.ProjectSettings.ProjectFolder.Website.Directory.Combine(new DirectoryInfo("bin"));
      var bin64BitFolder = args.ProjectSettings.ProjectFolder.Website.Directory.Combine(new DirectoryInfo("bin_x64"));

      Robocopy.Copy(bin64BitFolder, bin32BitFolder, DirCopyOptions.ExcludeSubDirectories);
    }
  }
}
