using System.IO;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class CopySitecore : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            var selectedSitecore = Services.BuildLibrary.Get(args.ProjectSettings.BuildLibrarySelections.SelectedSitecore, SourceType.Sitecore);
            if (selectedSitecore is BuildLibraryDirectory == false)
                throw new DirectoryNotFoundException("selected Sitecore was not of type BuildLibraryDirectory. Was:" + selectedSitecore.GetType());
            Services.WwwRoot.CopySitecoreToProjectfolder(args.ProjectSettings.ProjectFolder, selectedSitecore as BuildLibraryDirectory, args.ProjectSettings.Sql.InstallType);
        }
    }
}
