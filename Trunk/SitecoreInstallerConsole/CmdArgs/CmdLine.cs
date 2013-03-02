using System;
using System.Collections.Generic;

namespace SitecoreInstallerConsole.CmdArgs
{
  public class CmdLine
  {
    private readonly Dictionary<string, CmdLineParameter> _parameters = new Dictionary<string, CmdLineParameter>();

    public CmdLineParameter this[string name]
    {
      get
      {
        if (!_parameters.ContainsKey(name))
          return null;
        return _parameters[name];
      }
    }

    public void RegisterParameter(params CmdLineParameter[] parameters)
    {
      foreach (var p in parameters)
      {
        if (_parameters.ContainsKey(p.Name))
          throw new CmdLineException(p.Name, "Parameter is already registered.");
        _parameters.Add(p.Name, p);
      }
    }
    public bool UnRegisterParameter(string name)
    {
      if (_parameters.ContainsKey(name))
        return _parameters.Remove(name);
      return false;
    }

    public void ClearParameters()
    {
      _parameters.Clear();
    }

    public void Parse(string[] args)
    {
      string[] ret = null;
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
        Console.WriteLine("\r\n" + error);
        Console.WriteLine(this.HelpScreen());
        Environment.Exit(1);
      }
    }

    private void ParseArgs(string[] args)
    {
      int argsPointer = 0;

      while (argsPointer < args.Length)
      {
        var arg = args[argsPointer];

        if (IsParameter(arg))
        {
          string key = arg.TrimStart('-').ToLower();
          string value = string.Empty;
          argsPointer++;

          bool nextIsValue = true;

          while (nextIsValue && argsPointer < args.Length)
          {
            arg = args[argsPointer];
            if (IsParameter(arg))
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

      this.CheckRequiredParametersArePresent();
      this.CheckParametersHaveValues();
    }

    private void CheckParametersHaveValues()
    {
      foreach (var cmdLineParameter in this._parameters.Values)
      {
        if(cmdLineParameter.AllowEmptyValue || !cmdLineParameter.Exists)
          continue;
        if (string.IsNullOrEmpty(cmdLineParameter.Value))
          throw new CmdLineException(cmdLineParameter.Name, "Value is empty.");
      }
    }

    private void CheckRequiredParametersArePresent()
    {
      foreach (string key in this._parameters.Keys)
      {
        if (this._parameters[key].Required && !this._parameters[key].Exists)
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
        if(parameter.Required)
          s += "<Required> ";
        s += parameter.Help + "\r\n";
        help += s;
      }
      return help;
    }

  }
}
