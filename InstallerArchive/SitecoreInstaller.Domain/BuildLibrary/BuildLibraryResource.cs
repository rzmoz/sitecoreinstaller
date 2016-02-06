using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CSharp.Basics.IO;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.IOx;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public abstract class BuildLibraryResource
    {
        protected BuildLibraryResource(BuildLibraryMode buildLibraryMode)
        {
            Mode = buildLibraryMode;
        }

        public FileSystemInfo FileSystemInfo { get; protected set; }

        public DirectoryInfo TargetDirectory { get; set; }
        public BuildLibraryMode Mode { get; private set; }

        public void CopyToTargetDir(BuildLibraryMode newBuildLibraryMode)
        {
            //we don't copy if were already in local BuildLibraryMode
            if (Mode != BuildLibraryMode.Local)
                CopyToTargetDir();
            Mode = newBuildLibraryMode;
        }
        protected abstract void CopyToTargetDir();
        
        public abstract BuildLibraryResource Unpack();

        public override string ToString()
        {
            return FileSystemInfo.NameWithoutExtension();
        }
    }
}
