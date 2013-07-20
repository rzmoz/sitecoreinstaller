using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;
    using SitecoreInstaller.Domain.BuildLibrary;

  public class CopySitecore : Step<PipelineEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineEventArgs args)
        {
            var selectedSitecore = Services.BuildLibrary.Get(args.ProjectSettings.BuildLibrarySelections.SelectedSitecore, SourceType.Sitecore);
            if (selectedSitecore is BuildLibraryDirectory == false)
                throw new DirectoryNotFoundException("selected Sitecore was not of type BuildLibraryDirectory. Was:" + selectedSitecore.GetType());
            Services.Website.CopySitecoreToProjectfolder(args.ProjectSettings.ProjectFolder, selectedSitecore as BuildLibraryDirectory, args.ProjectSettings.InstallType);
        }
    }
}
