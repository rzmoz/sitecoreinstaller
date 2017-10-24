using System;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.Resources
{
    public class SitecoreInstallerConfig
    {
        public SitecoreInstallerConfig()
        {
            DataDirRoot = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToDir();
        }

        public DirPath DataDirRoot { get; }
    }
}
