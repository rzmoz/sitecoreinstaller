using System.IO;
using CSharp.Basics.IO;
using SitecoreInstaller.Framework.IOx;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class BuildLibraryDirectory : BuildLibraryResource
    {
        internal BuildLibraryDirectory(DirectoryInfo directoryInfo, BuildLibraryMode buildLibraryMode)
            : base(buildLibraryMode)
        {
            Directory = directoryInfo;
        }

        internal DirectoryInfo Directory
        {
            get { return (DirectoryInfo)FileSystemInfo; }
            set { FileSystemInfo = value; }
        }

        protected override void CopyToTargetDir()
        {
            if (TargetDirectory == null)
                return;
            if (Directory.Parent == null)
                return;
            if (Directory.Parent.FullName.Equals(TargetDirectory.FullName))
                return;

            Directory.CopyTo(TargetDirectory.Combine(Directory), DirCopyOptions.IncludeSubDirectories);
            Directory = TargetDirectory;
            Directory.ConsolidateIdenticalSubfolders();
        }

        public override BuildLibraryResource Unpack()
        {
            return this;
        }
    }
}
