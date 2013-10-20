using System.Linq;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class CopyModuleFiles : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      var selectedModules = from module in args.ProjectSettings.BuildLibrarySelections.SelectedModules
                            select Services.BuildLibrary.Get(module, SourceType.Module);

      foreach (var module in selectedModules.OfType<BuildLibraryDirectory>())
        Services.Website.CopyModulesToWebsite(args.ProjectSettings.ProjectFolder, module, args.ProjectSettings.InstallType);
    }
  }
}
