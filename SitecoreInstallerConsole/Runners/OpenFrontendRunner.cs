namespace SitecoreInstallerConsole.Runners
{
  using SitecoreInstaller.App;

  public class OpenFrontendRunner : ConsolePipelineRunner
  {
    public OpenFrontendRunner()
    {
      CmdLine.RegisterParameter(SitecoreInstallerParameters.Open);
      CmdLine[SitecoreInstallerParameters.Open.Name].Required = true;
    }

    public override void Run(ProjectSettings projectSettings)
    {
      var projectName = CmdLine[SitecoreInstallerParameters.Open.Name];
      projectSettings.ProjectName = projectName.Value;
      Services.Website.OpenFrontend(projectSettings.Iis.Url);
    }
  }
}
