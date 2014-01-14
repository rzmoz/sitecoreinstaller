
using System;
using System.Collections.Generic;

namespace SitecoreInstaller.Framework.CmdArgs
{
    public class CmdLine
    {
        private readonly Dictionary<string, CmdLineParameter> _parameters = new Dictionary<string, CmdLineParameter>();

        public CmdLineParameter this[CmdLineParameter cmdParam]
        {
            get
            {
                return _parameters[cmdParam.Name];
            }
        }
        private CmdLineParameter this[string name]
        {
            get
            {
                var key = name.ToLower();
                if (!_parameters.ContainsKey(key))
                    return null;
                return _parameters[key];
            }
        }

        public void RegisterParameter(params CmdLineParameter[] parameters)
        {
            foreach (var p in parameters)
            {
                var key = p.Name.ToLower();
                if (_parameters.ContainsKey(key))
                    throw new CmdLineException(key, "Parameter is already registered.");
                _parameters.Add(key, p);
            }
        }
        public bool UnRegisterParameter(string name)
        {
            var key = name.ToLower();
            if (_parameters.ContainsKey(key))
                return _parameters.Remove(key);
            return false;
        }

        public void ClearParameters()
        {
            _parameters.Clear();
        }

        public void Parse(string[] args)
        {
            string error = string.Empty;
            try
            {
                ParseArgs(args);
            }
            catch (CmdLineException ex)
            {
                error = ex.Message;
            }

            if (error != string.Empty)
            {
                Console.WriteLine(Environment.NewLine + error);
                Console.WriteLine(HelpScreen());
                Environment.Exit(1);
            }
        }

        private void ParseArgs(string[] args)
        {
            int argsPointer = 0;

            while (argsPointer < args.Length)
            {
                var arg = args[argsPointer];

                if (this.IsParameter(arg))
                {
                    string key = arg.TrimStart('-').ToLower();
                    string value = string.Empty;
                    argsPointer++;

                    bool nextIsValue = true;

                    while (nextIsValue && argsPointer < args.Length)
                    {
                        arg = args[argsPointer];
                        if (this.IsParameter(arg))
                        {
                            nextIsValue = false;
                        }
                        else
                        {
                            // The next string is a value, read the value and move forward
                            value += "|" + arg;
                            argsPointer++;
                        }
                    }
                    if (!_parameters.ContainsKey(key))
                        throw new CmdLineException(key, "Parameter is not recognized.");

                    if (_parameters[key].Exists)
                        throw new CmdLineException(key, "Parameter is   specified more than once.");

                    _parameters[key].SetValue(value.Trim('|'));
                }
                else
                {
                    argsPointer++;
                }
            }

            CheckRequiredParametersArePresent();
            CheckParametersHaveValues();
        }

        private void CheckParametersHaveValues()
        {
            foreach (var cmdLineParameter in _parameters.Values)
            {
                if (cmdLineParameter.AllowEmptyValue || !cmdLineParameter.Exists)
                    continue;
                if (string.IsNullOrEmpty(cmdLineParameter.Value))
                    throw new CmdLineException(cmdLineParameter.Name, "Value is empty.");
            }
        }

        private void CheckRequiredParametersArePresent()
        {
            foreach (string key in _parameters.Keys)
            {
                if (_parameters[key].Required && !_parameters[key].Exists)
                    throw new CmdLineException(key, "Required parameter is not found.");
            }
        }

        private bool IsParameter(string s)
        {
            return s.Length > 0 && s[0] == '-';
        }

        public string HelpScreen()
        {
            int len = 0;

            foreach (string key in _parameters.Keys)
                len = Math.Max(len, key.Length);

            string help = "\nParameters:\r\n\r\n";
            foreach (var parameter in _parameters.Values)
            {
                string s = "-" + parameter.Name;
                while (s.Length < len + 3)
                    s += " ";
                if (parameter.Required)
                    s += "<Required> ";
                s += parameter.Help + Environment.NewLine;
                help += s;
            }
            return help;
        }

    }
}
