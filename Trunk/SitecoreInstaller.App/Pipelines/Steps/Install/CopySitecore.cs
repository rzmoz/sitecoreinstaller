using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;
    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.Domain.Pipelines;

    public class CopySitecore : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            var selectedSitecore = Services.BuildLibrary.Get(Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore, SourceType.Sitecore);
            if (selectedSitecore is BuildLibraryDirectory == false)
                throw new DirectoryNotFoundException("selected Sitecore was not of type BuildLibraryDirectory. Was:" + selectedSitecore.GetType());
            Services.Website.CopySitecoreToProjectfolder(Services.ProjectSettings.ProjectFolder, selectedSitecore as BuildLibraryDirectory, Services.ProjectSettings.InstallType);
        }
    }
}
