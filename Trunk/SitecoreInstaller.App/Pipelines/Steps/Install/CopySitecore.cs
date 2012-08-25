using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;
    using SitecoreInstaller.Domain.BuildLibrary;

    public class CopySitecore:Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var selectedSitecore = Services.BuildLibrary.Get(Services.AppSettings.UserSelections.SelectedSitecore, SourceType.Sitecore);
            if (selectedSitecore is BuildLibraryDirectory == false)
                throw new DirectoryNotFoundException("selected Sitecore was not of type BuildLibraryDirectory. Was:" + selectedSitecore.GetType());
            Services.Website.CopySitecoreToProjectfolder(Services.AppSettings.WebsiteFolders, selectedSitecore as BuildLibraryDirectory);
        }
    }
}
