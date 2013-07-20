using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.Domain.Pipelines;

  public class InstallPackages : Step<PipelineEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineEventArgs args)
        {
            var selectedModules = Services.BuildLibrary.Get(args.ProjectSettings.BuildLibrarySelections.SelectedModules, SourceType.Module);
            Services.Website.InstallPackages(args.ProjectSettings.Iis.Url, selectedModules.OfType<BuildLibraryDirectory>());
        }
    }
}
