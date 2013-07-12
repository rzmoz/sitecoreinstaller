using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps
{
  using SitecoreInstaller.Framework.IO;

  public abstract class PowerShellScriptStep : Step
  {
    protected override void InnerInvoke(object sender, StepEventArgs args)
    {
      var scripts = FileTypes.PowerShellScript.GetFiles(Services.ProjectSettings.ProjectFolder.Directory);
      Services.PowerShellScripts.RunScripts(scripts, MethodName, "projectSettings", Services.ProjectSettings);
    }
    protected abstract string MethodName { get; }
  }
}
