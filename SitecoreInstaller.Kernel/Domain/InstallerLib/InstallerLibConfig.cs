using System;
using DotNet.Basics.IO;

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
