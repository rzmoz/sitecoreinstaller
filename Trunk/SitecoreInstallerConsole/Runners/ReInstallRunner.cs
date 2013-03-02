using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstallerConsole.Runners
{
  using SitecoreInstaller.App;
  using SitecoreInstaller.App.Pipelines;
  using SitecoreInstaller.Domain.Pipelines;
  using SitecoreInstallerConsole.CmdArgs;

  public class ReInstallRunner : ConsolePipelineRunner
  {
    public ReInstallRunner()
    {
      CmdLine.RegisterParameter(SitecoreInstallerParameters.Install);
      CmdLine[SitecoreInstallerParameters.UnInstall.Name].Required = true;
    }

    public override void Run()
    {
      var projectName = CmdLine[SitecoreInstallerParameters.ReInstall.Name];
      Services.ProjectSettings.ProjectName = projectName.Value;
      Services.Pipelines.Run<ReinstallPipeline>(Dialogs.Off);
    }
  }
}
