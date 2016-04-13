using System.Linq;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class InstallPackages : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            var selectedModules = (Services.BuildLibrary.Get(args.ProjectSettings.BuildLibrarySelections.SelectedModules, SourceType.Module)).ToList();
            Services.Website.InstallPackages(args.ProjectSettings.Iis.Url, selectedModules.OfType<BuildLibraryDirectory>());
            Services.Website.InstallPackages(args.ProjectSettings.Iis.Url, selectedModules.OfType<BuildLibraryFile>());
        }
    }
}
