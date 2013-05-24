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

    public override void Run()
    {
      var projectName = CmdLine[SitecoreInstallerParameters.Open.Name];
      Services.ProjectSettings.ProjectName = projectName.Value;
      Services.Website.OpenFrontend(Services.ProjectSettings.Iis.Url);
    }
  }
}
