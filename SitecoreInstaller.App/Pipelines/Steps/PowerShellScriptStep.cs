using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps
{
  using SitecoreInstaller.Framework.IO;

  public abstract class PowerShellScriptStep : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      var scripts = FileTypes.PowerShellScript.GetFiles(args.ProjectSettings.ProjectFolder.Directory);
      Services.PowerShellScripts.RunScripts(scripts, MethodName, "projectSettings", args.ProjectSettings);
    }
    protected abstract string MethodName { get; }
  }
}
