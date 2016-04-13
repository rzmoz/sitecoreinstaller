using System.Linq;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class CopyModuleFiles : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            var selectedModules = (from module in args.ProjectSettings.BuildLibrarySelections.SelectedModules
                                   select Services.BuildLibrary.Get(module, SourceType.Module)).ToList();

            foreach (var module in selectedModules.OfType<BuildLibraryDirectory>())
                Services.WwwRoot.CopyModule(args.ProjectSettings.ProjectFolder, module, args.ProjectSettings.Sql.InstallType);

            foreach (var file in selectedModules.OfType<BuildLibraryFile>())
                Services.WwwRoot.CopyStandAloneScPackage(args.ProjectSettings.ProjectFolder, file, args.ProjectSettings.Sql.InstallType);
        }
    }
}
