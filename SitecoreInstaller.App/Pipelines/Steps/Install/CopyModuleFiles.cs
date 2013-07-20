using System.Linq;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  using SitecoreInstaller.Domain.BuildLibrary;

  public class CopyModuleFiles : Step
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
