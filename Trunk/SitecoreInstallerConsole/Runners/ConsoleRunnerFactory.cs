using System;

namespace SitecoreInstallerConsole.Runners
{
  using SitecoreInstallerConsole.CmdArgs;

  public class ConsoleRunnerFactory
  {
    public ConsolePipelineRunner Create(string[] args)
    {
      if (args == null || args.Length == 0)
        return null;
      var mainSwitch = args[0].Trim('-');

      if (mainSwitch == SitecoreInstallerParameters.List.Name)
        return new ListRunner();
      if (mainSwitch == SitecoreInstallerParameters.Projects.Name)
        return new ExistingProjectsRunner();
      if (mainSwitch == SitecoreInstallerParameters.Install.Name)
        return new InstallRunner();
      if (mainSwitch == SitecoreInstallerParameters.UnInstall.Name)
        return new UnInstallRunner();
      if (mainSwitch == SitecoreInstallerParameters.Open.Name)
        return new OpenFrontendRunner();
      return null;

    }
  }
}
