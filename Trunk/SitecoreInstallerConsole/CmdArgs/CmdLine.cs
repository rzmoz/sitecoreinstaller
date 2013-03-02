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

    public string[] Parse(string[] args)
    {
      string[] ret = null;
      string error = string.Empty;
      try
      {
        ret = ParseArgs(args);
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
      return ret;
    }

    private string[] ParseArgs(string[] args)
    {
      int i = 0;

      var newArgs = new List<string>();

      while (i < args.Length)
      {
        if (args[i].Length > 1 && args[i][0] == '-')
        {
          // The current string is a parameter name
          string key = args[i].Substring(1, args[i].Length - 1).ToLower();
          string value = string.Empty;
          i++;
          if (i < args.Length)
          {
            if (args[i].Length > 0 && args[i][0] == '-')
            {
              // The next string is a new parameter, do not nothing
            }
            else
            {
              // The next string is a value, read the value and move forward
              value = args[i];
              i++;
            }
          }
          if (!_parameters.ContainsKey(key))
            throw new CmdLineException(key, "Parameter is not allowed.");

          if (_parameters[key].Exists)
            throw new CmdLineException(key, "Parameter is specified more than once.");

          _parameters[key].SetValue(value);
        }
        else
        {
          newArgs.Add(args[i]);
          i++;
        }
      }


      // Check that required parameters are present in the command line. 
      foreach (string key in _parameters.Keys)
        if (_parameters[key].Required && !_parameters[key].Exists)
          throw new CmdLineException(key, "Required parameter is not found.");

      return newArgs.ToArray();
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
