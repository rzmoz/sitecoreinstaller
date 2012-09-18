using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using SitecoreInstaller.Domain.BuildLibrary;

    public class InstallPackages : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var selectedModules = Services.BuildLibrary.Get(Services.AppSettings.BuildLibrarySelections.SelectedModules, SourceType.Module);
            Services.Website.InstallPackages(Services.AppSettings.Iis.Url, selectedModules.OfType<BuildLibraryDirectory>());
        }
    }
}
