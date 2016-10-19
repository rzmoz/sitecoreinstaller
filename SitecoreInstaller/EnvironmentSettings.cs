using System;
using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public class EnvironmentSettings
    {
        public EnvironmentSettings()
        {
            SitesRootDir = @"c:\inetpub\scroot\";
            BuildLibraryRootDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData).ToDir("SiBuildLibrary").FullName;
        }

        public string SitesRootDir { get; set; }
        public string BuildLibraryRootDir { get; set; }
    }
}
