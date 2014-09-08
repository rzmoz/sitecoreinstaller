using System;
using System.Collections.Generic;
using System.IO;
using CSharp.Basics;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Domain.WebServer
{
    public class PowerShellScriptService
    {
        public void RunScripts(IEnumerable<FileInfo> scripts, string methodName, string argName, object arg)
        {
            var psr = new PowerShellConsole();

            foreach (var script in scripts)
            {
                try
                {
                    Log.As.Debug("Trying to execute '{0}' in '{1}'", methodName, script.FullName);
                    var result = psr.RunFunction(methodName, new KeyValuePair<string, object>(argName, arg), script);
                    Log.As.Debug(result);
                    Log.As.Debug("'{0}' in '{1}' was executed", methodName, script.FullName);
                }
                catch (System.Management.Automation.CommandNotFoundException)
                {
                    Log.As.Debug("Method wasn't found: '{0}'", methodName);
                }
                catch (Exception e)
                {
                    Log.As.Error(e.ToString());
                }
            }
        }
    }
}
