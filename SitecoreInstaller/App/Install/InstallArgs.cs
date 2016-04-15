using System;
using System.IO;

namespace SitecoreInstaller.App.Install
{
    public class InstallArgs : EventArgs
    {
        public DirectoryInfo InstallDir { get; set; }
        public DirectoryInfo WebsiteRoot { get; set; }
        public DirectoryInfo Sitecore { get; set; }
        public FileInfo License { get; set; }
        public FileSystemInfo[] Modules { get; set; }

        public UserPreferences UserPreferences { get; } = new UserPreferences();
    }
}