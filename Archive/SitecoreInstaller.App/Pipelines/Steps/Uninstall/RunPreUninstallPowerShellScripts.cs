using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps.Uninstall
{
    class RunPreUninstallPowerShellScripts : PowerShellScriptStep
    {
        protected override string MethodName
        {
            get { return "Pre-Uninstall"; }
        }
    }
}
