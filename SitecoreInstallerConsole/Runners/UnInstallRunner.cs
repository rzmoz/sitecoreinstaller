using System.Threading.Tasks;
using SitecoreInstaller.App;

namespace SitecoreInstallerConsole.Runners
{
    using SitecoreInstaller.App.Pipelines;

    public class UnInstallRunner : ConsolePipelineRunner
    {
        public UnInstallRunner()
        {
            CmdLine.RegisterParameter(SitecoreInstallerParameters.UnInstall);
            CmdLine[SitecoreInstallerParameters.UnInstall].Required = true;
        }

        public override void Run(ProjectSettings projectSettings)
        {
            var projectName = CmdLine[SitecoreInstallerParameters.UnInstall];
            projectSettings.ProjectName = projectName.Value;
            Task.WaitAll(Services.Pipelines.RunAsync<UninstallPipeline, CleanupEventArgs>(projectSettings));
        }
    }
}
