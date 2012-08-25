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
        public CopyLicensefile(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var license = Services.BuildLibrary.Get(AppSettings.UserSelections.SelectedLicense, SourceType.License);
            if (license is BuildLibraryFile == false)
                throw new DirectoryNotFoundException("license was not of type BuildLibraryFile. Was:" + license.GetType());
            Services.Website.CopyLicenseFileToDataFolder(license as BuildLibraryFile, AppSettings.WebsiteFolders.DataFolder, AppSettings.LicenseConfigFile);
        }
    }
}
