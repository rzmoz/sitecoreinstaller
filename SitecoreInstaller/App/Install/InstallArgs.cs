using System;
using System.IO;

namespace SitecoreInstaller.App.Install
{
    public class InstallArgs : EventArgs
    {
        public DirectoryInfo InstallDir { get; set; }
        public DirectoryInfo WebsiteRoot { get; set; }
        public string SitecoreName { get; set; }
        public string LicenseName { get; set; }
        public string[] ModuleNames { get; set; }

        public UserPreferences UserPreferences { get; } = new UserPreferences();
    }
}