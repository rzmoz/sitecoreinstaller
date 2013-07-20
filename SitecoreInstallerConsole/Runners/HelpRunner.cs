using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstallerConsole.Runners
{
  using SitecoreInstaller.App;
  using SitecoreInstaller.Framework.CmdArgs;

  public class HelpRunner : ConsolePipelineRunner
  {
    private readonly CmdLine _cmdLine;
    private readonly string[] _args;
    public HelpRunner(string[] args)
    {
      _args = args;
      this._cmdLine = new CmdLine();
    }

    public override void Run(ProjectSettings projectSettings)
    {
      _cmdLine.RegisterParameter(SitecoreInstallerParameters.List,
                      SitecoreInstallerParameters.Projects,
                      SitecoreInstallerParameters.Open,
                      SitecoreInstallerParameters.Install,
                      SitecoreInstallerParameters.UnInstall);
      _cmdLine.Parse(_args);
      Console.WriteLine(_cmdLine.HelpScreen());
    }
  }
}
