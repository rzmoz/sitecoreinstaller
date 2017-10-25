using System;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.InstallerLib
{
    public class InstallerLibConfig

    {
        public InstallerLibConfig()
        {
            DataDirRoot = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToDir();
        }

        public DirPath DataDirRoot { get; }
    }
}
