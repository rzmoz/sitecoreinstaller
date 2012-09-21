using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using SitecoreInstaller.Domain.BuildLibrary;

    public class CopyModuleFiles : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var selectedModules = from module in Services.ProjectSettings.BuildLibrarySelections.SelectedModules
                                  select Services.BuildLibrary.Get(module, SourceType.Module);
            Services.Website.CopyModulesToWebsite(Services.ProjectSettings.WebsiteFolders.ProjectFolder, Services.ProjectSettings.WebsiteFolders, selectedModules.OfType<BuildLibraryDirectory>());
        }
    }
}
