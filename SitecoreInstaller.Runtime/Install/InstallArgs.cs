using System;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Runtime.Install
{
    public class InstallArgs : EventArgs
    {
        public DirPath InstallDir { get; set; }
        public DirPath WebsiteRoot { get; set; }
        public DirPath Sitecore { get; set; }
        public FilePath License { get; set; }
        public Path[] Modules { get; set; }

        public UserPreferences UserPreferences { get; } = new UserPreferences();

        public static InstallArgs Create(string projectName, string version, string license, string[] modules)
        {
            throw new NotImplementedException();
        }
    }
}