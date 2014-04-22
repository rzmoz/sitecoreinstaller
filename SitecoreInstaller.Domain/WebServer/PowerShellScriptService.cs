using System;
using System.Collections.Generic;
using System.IO;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.Scripting;

namespace SitecoreInstaller.Domain.WebServer
{
    public class PowerShellScriptService
    {
        public void RunScripts(IEnumerable<FileInfo> scripts, string methodName, string argName, object arg)
        {
            var psr = new PowerShellRunner();

            foreach (var script in scripts)
            {
                try
                {
                    Log.ToApp.Debug("Trying to execute '{0}' in '{1}'", methodName, script.FullName);
                    var result = psr.RunPowerShellFunction(methodName, new KeyValuePair<string, object>(argName, arg),
                        script);
                    Log.ToApp.Debug(result);
                    Log.ToApp.Debug("'{0}' in '{1}' was executed", methodName, script.FullName);
                }
                catch (System.Management.Automation.CommandNotFoundException)
                {
                    Log.ToApp.Debug("Method wasn't found: '{0}'", methodName);
                }
                catch (Exception e)
                {
                    Log.ToApp.Error(e.ToString());
                }
            }
        }
    }
}
