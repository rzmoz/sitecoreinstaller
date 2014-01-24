using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class CopyLicenseFile : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            var license = Services.BuildLibrary.Get(args.ProjectSettings.BuildLibrarySelections.SelectedLicense, SourceType.License);
            if (license is BuildLibraryFile == false)
                throw new DirectoryNotFoundException("license was not of type BuildLibraryFile. Was:" + license.GetType());
            Services.Website.CopyLicenseFileToDataFolder(license as BuildLibraryFile, args.ProjectSettings.ProjectFolder.Data, args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.LicenseConfigFile);
        }
    }
}
