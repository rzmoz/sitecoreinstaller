using System.Collections.Generic;
using System.IO;
using System.Linq;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Domain.Website;
using SitecoreInstaller.Framework.IOx;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class TransformConfigFiles : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            var selectedModules = (from module in args.ProjectSettings.BuildLibrarySelections.SelectedModules
                                   select Services.BuildLibrary.Get(module, SourceType.Module)).ToList();

            var deltaFiles = new List<ProjectDeltaFile>();

            //get all delta files from modules
            foreach (var module in selectedModules.OfType<BuildLibraryDirectory>())
            {
                var deltaFilesInModule = ((DirectoryInfo)module.FileSystemInfo).GetFiles(FileTypes.ConfigDelta.GetAllSearchPattern, SearchOption.AllDirectories);
                foreach (var deltaFileInModule in deltaFilesInModule)
                {
                    deltaFiles.Add(new ProjectDeltaFile(module.FileSystemInfo.Name, deltaFileInModule));
                }
            }

            Services.WwwRoot.TransformConfigFiles(args.ProjectSettings.ProjectFolder, deltaFiles);
        }
    }
}
