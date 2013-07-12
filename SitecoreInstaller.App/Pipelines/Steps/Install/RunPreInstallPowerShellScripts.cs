namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class RunPreInstallPowerShellScripts : PowerShellScriptStep
  {
    protected override string MethodName
    {
      get { return "Pre-Install"; }
    }
  }
}
