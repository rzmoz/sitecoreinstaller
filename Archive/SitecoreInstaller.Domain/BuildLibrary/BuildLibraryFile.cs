using CSharp.Basics.SevenZip;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.IOx;
using System.IO;
using System;
using CSharp.Basics.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class BuildLibraryFile : BuildLibraryResource
    {
        private readonly Func<BuildLibraryResource> _unpack;

        internal BuildLibraryFile(FileInfo fileInfo, BuildLibraryFileCopyOptions buildLibraryFileCopyOptions)
            : this(fileInfo, BuildLibraryMode.External)
        {
            BuildLibraryFileCopyOptions = buildLibraryFileCopyOptions;
        }

        internal BuildLibraryFile(FileInfo fileInfo, BuildLibraryMode buildLibraryMode = BuildLibraryMode.External)
            : base(buildLibraryMode)
        {
            File = fileInfo;
            BuildLibraryFileCopyOptions = BuildLibraryFileCopyOptions.JustCopy;
            if (fileInfo.IsZipfile() && !fileInfo.IsSitecorePackage())
                _unpack = UnpackZipFile;//regular zip files
            else
                _unpack = DontUnpackFile; //sitecore packages and all files that are not zip files
        }

        public FileInfo File
        {
            get { return (FileInfo)FileSystemInfo; }
            set { FileSystemInfo = value; }
        }

        public BuildLibraryFileCopyOptions BuildLibraryFileCopyOptions { get; private set; }

        protected override void CopyToTargetDir()
        {
            if (TargetDirectory == null)
                return;
            if (File.ExistsInDir(TargetDirectory))
                return;

            var newFile = TargetDirectory.CombineTo<FileInfo>(File.Name);

            newFile.Directory.CreateIfNotExists();
            File.CopyTo(newFile.FullName);

            if (BuildLibraryFileCopyOptions == BuildLibraryFileCopyOptions.DeleteAfterCopy)
                File.TryDelete();

            File = newFile;
        }

        public override BuildLibraryResource Unpack()
        {
            return _unpack();
        }
        private BuildLibraryResource UnpackZipFile()
        {
            var targetDirectory = File.Directory.CombineTo<DirectoryInfo>(File.NameWithoutExtension());

            targetDirectory.CreateIfNotExists();

            try
            {
                Log.As.Info("Extracting '{0}'", File.Name);
                var zipFile = new SevenZipFile(File);
                zipFile.ExtractAll(targetDirectory);
            }
            catch (Exception)
            {
                //we delete target directory since extraction crashed and therefore left it in an invalid state
                targetDirectory.Delete(true);
                throw;
            }

            try
            {
                FileSystemInfo.Delete();
            }
            catch (IOException)
            {
            }

            targetDirectory.ConsolidateIdenticalSubfolders();
            return new BuildLibraryDirectory(targetDirectory, Mode);
        }
        private BuildLibraryResource DontUnpackFile()
        {
            if (Mode != BuildLibraryMode.Local)
            {
                var targetDirectory = File.Directory.CombineTo<DirectoryInfo>(File.NameWithoutExtension());
                targetDirectory.CreateIfNotExists();
                File.MoveTo(targetDirectory, true);
                File = targetDirectory.CombineTo<FileInfo>(File.Name);
            }
            return this;
        }
    }
}
