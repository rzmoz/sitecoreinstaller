using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new CmdLineException(key, "Parameter is not allowed.");

          if (_parameters[key].Exists)
            throw new CmdLineException(key, "Parameter is   specified more than once.");

          _parameters[key].SetValue(value.Trim('|'));
        }
        else
        {
          argsPointer++;
        }
      }

      // Check that required parameters are present in the command line. 
      foreach (string key in _parameters.Keys)
        if (_parameters[key].Required && !_parameters[key].Exists)
          throw new CmdLineException(key, "Required parameter is not found.");

      //check that parameters have values
      foreach (var cmdLineParameter in _parameters.Values)
      {
        if(string.IsNullOrEmpty(cmdLineParameter.Value))
          throw new CmdLineException(cmdLineParameter.Name, "Value is empty.");
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
      foreach (string key in _parameters.Keys)
      {
        string s = "-" + _parameters[key].Name;
        while (s.Length < len + 3)
          s += " ";
        s += _parameters[key].Help + "\r\n";
        help += s;
      }
      return help;
    }

  }
}
