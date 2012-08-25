using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using SitecoreInstaller.Domain.BuildLibrary;

    public class InstallPackages : Step
    {
        public InstallPackages(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var selectedModules = Services.BuildLibrary.Get(AppSettings.UserSelections.SelectedModules, SourceType.Module);
            Services.Website.InstallPackages(AppSettings.IisSiteName, selectedModules.OfType<BuildLibraryDirectory>());
        }
    }
}
