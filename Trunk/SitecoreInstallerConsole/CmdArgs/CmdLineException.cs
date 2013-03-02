using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstallerConsole.CmdArgs
{
  public class CmdLineException : Exception
  {
    public CmdLineException(string parameter, string message) 
      : base(string.Format("Syntax error of parameter -{0}: {1}", parameter, message))
    {
    }
    public CmdLineException(string message)
      : base(message)
    {
    }
  }
}
