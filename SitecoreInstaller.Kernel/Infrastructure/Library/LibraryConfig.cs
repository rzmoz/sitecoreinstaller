using System;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Infrastructure.Library
{
    public class LibraryConfig

    {
        public LibraryConfig()
        {
            DataDirRoot = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToDir();
        }

        public DirPath DataDirRoot { get; }
    }
}
