using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.Domain.Pipelines;

    public class InstallPackages : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            var selectedModules = Services.BuildLibrary.Get(Services.ProjectSettings.BuildLibrarySelections.SelectedModules, SourceType.Module);
            Services.Website.InstallPackages(Services.ProjectSettings.Iis.Url, selectedModules.OfType<BuildLibraryDirectory>());
        }
    }
}
