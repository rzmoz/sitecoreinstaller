using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;

    using SitecoreInstaller.Domain.BuildLibrary;

    public class CopyLicensefile : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var license = Services.BuildLibrary.Get(Services.ProjectSettings.BuildLibrarySelections.SelectedLicense, SourceType.License);
            if (license is BuildLibraryFile == false)
                throw new DirectoryNotFoundException("license was not of type BuildLibraryFile. Was:" + license.GetType());
            Services.Website.CopyLicenseFileToDataFolder(license as BuildLibraryFile, Services.ProjectSettings.ProjectFolder.Data, Services.ProjectSettings.LicenseConfigFile);
        }
    }
}
