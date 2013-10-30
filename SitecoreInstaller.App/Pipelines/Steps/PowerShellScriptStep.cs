using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps
{
  using SitecoreInstaller.Framework.IO;

  public abstract class PowerShellScriptStep : Step<PipelineApplicationEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
    {
      var scripts = args.ProjectSettings.ProjectFolder.Directory.GetFiles(FileTypes.PowerShellScript);
      Services.PowerShellScripts.RunScripts(scripts, MethodName, "projectSettings", args.ProjectSettings);
    }
    protected abstract string MethodName { get; }
  }
}
