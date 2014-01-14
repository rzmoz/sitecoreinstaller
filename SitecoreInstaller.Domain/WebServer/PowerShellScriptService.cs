﻿using System;
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
            try
            {
                foreach (var script in scripts)
                {
                    var result = psr.RunPowerShellFunction("Post-Install", new KeyValuePair<string, object>(argName, arg), script);
                    Log.ToApp.Debug(result);
                }
            }
            catch (Exception e)
            {
                Log.ToApp.Error(e.ToString());
            }
        }
    }
}
