using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.App.Pipelines.Steps
{
    public abstract class PowerShellScriptStep : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            var scripts = args.ProjectSettings.ProjectFolder.Directory.GetFiles(FileTypes.PowerShellScript);
            Services.PowerShellScripts.RunScripts(scripts, MethodName, "projectSettings", args.ProjectSettings);
        }
        protected abstract string MethodName { get; }
    }
}
