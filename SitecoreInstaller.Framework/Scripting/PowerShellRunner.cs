namespace SitecoreInstaller.Framework.Scripting
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Management.Automation;
    using System.Text;

    public class PowerShellRunner
    {
        public string RunPowerShellFunction(string method, KeyValuePair<string, object> arg, FileInfo script)
        {
            if (method == null) { throw new ArgumentNullException("method"); }
            if (script == null) { throw new ArgumentNullException("script"); }
            
            if (File.Exists(script.FullName) == false)
                throw new ArgumentException("Script not found at:" + script.FullName);

            using (var ps = PowerShell.Create())
            {
                /*
                AddExecutionPolicy(ps);
                ps.AddScript(". '" + script.FullName + "'");
                var results1 = ps.Invoke();

                ps.Commands.Clear();

                AddExecutionPolicy(ps);
                 * */
                ps.AddCommand(File.ReadAllText(script.FullName));
                ps.AddCommand(method).AddParameter(arg.Key, arg.Value);

                var results = ps.Invoke();

                var resultString = new StringBuilder();

                foreach (var psObject in results)
                {
                    resultString.Append(psObject + Environment.NewLine);
                }

                return resultString.ToString().TrimEnd(Environment.NewLine.ToCharArray());
            }
        }

        private void AddExecutionPolicy(PowerShell ps)
        {
            ps.AddScript("Set-ExecutionPolicy Bypass -Scope Process");
        }
    }
}