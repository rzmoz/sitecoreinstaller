using System;
using SitecoreInstaller;
using SitecoreInstaller.App;

namespace SitecoreInstallerConsole.Runners
{
  using SitecoreInstaller.App.Pipelines;
  using SitecoreInstaller.Domain.Pipelines;

  public class UnInstallRunner : ConsolePipelineRunner
  {
    public UnInstallRunner()
    {
      CmdLine.RegisterParameter(SitecoreInstallerParameters.UnInstall);
      CmdLine[SitecoreInstallerParameters.UnInstall.Name].Required = true;
    }

    public override void Run()
    {
      var projectName = CmdLine[SitecoreInstallerParameters.UnInstall.Name];
      Services.ProjectSettings.ProjectName = projectName.Value;
      Services.Pipelines.Run<UninstallPipeline>(Dialogs.Off);
    }
  }
}
