namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class RunPostInstallPowerShellScripts : PowerShellScriptStep
    {
        protected override string MethodName
        {
            get { return "Post-Install"; }
        }
    }
}
