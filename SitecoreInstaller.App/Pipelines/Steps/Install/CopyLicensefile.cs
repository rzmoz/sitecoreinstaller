using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;

    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.Domain.Pipelines;

    public class CopyLicensefile : Step
    {
        protected override void InnerInvoke(object sender, PipelineEventArgs args)
        {
            var license = Services.BuildLibrary.Get(args.ProjectSettings.BuildLibrarySelections.SelectedLicense, SourceType.License);
            if (license is BuildLibraryFile == false)
                throw new DirectoryNotFoundException("license was not of type BuildLibraryFile. Was:" + license.GetType());
            Services.Website.CopyLicenseFileToDataFolder(license as BuildLibraryFile, args.ProjectSettings.ProjectFolder.Data, args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.LicenseConfigFile);
        }
    }
}
