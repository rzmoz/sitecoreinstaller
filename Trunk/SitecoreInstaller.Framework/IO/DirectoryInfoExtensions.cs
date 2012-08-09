using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SitecoreInstaller.Framework.IO
{
    public static class DirectoryInfoExtensions
    {
        private static readonly FileSystemInfoFactory _fileSystemInfoFactory;

        static DirectoryInfoExtensions()
        {
            _fileSystemInfoFactory = new FileSystemInfoFactory();
        }

        public static T Combine<T>(this DirectoryInfo directoryInfo, params T[] paths) where T : FileSystemInfo
        {
            var combinedString = CombineToString(directoryInfo, paths);
            return _fileSystemInfoFactory.Create<T>(combinedString);
        }
        public static T CombineTo<T>(this DirectoryInfo directoryInfo, params string[] paths) where T : FileSystemInfo
        {
            var combinedString = CombineToString(directoryInfo, paths.Select(path => new FileInfo(path)).ToArray());
            return _fileSystemInfoFactory.Create<T>(combinedString);
        }

        private static string CombineToString(DirectoryInfo rootDirectory, params FileSystemInfo[] pathTokens)
        {
            var paths = new List<string> { rootDirectory.FullName };
            paths.AddRange(pathTokens.Select(path => path.Name));
            var combinedPath = Path.Combine(paths.ToArray());
            return combinedPath;
        }

        public static bool ParentHasIdenticalName(this DirectoryInfo dir)
        {
            if (dir == null)
                return false;
            if (Directory.Exists(dir.FullName) == false)
                return false;
            if (dir.Parent == null)
                return false;
            return dir.Name.Equals(dir.Parent.Name);
        }

        public static bool TryGetIdenticallyNamedSubDir(this DirectoryInfo dir, out DirectoryInfo identicalChild)
        {
            identicalChild = null;
            if (dir == null)
                return false;
            if (Directory.Exists(dir.FullName) == false)
                return false;

            var identicalSubFolders = dir.GetDirectories(dir.Name);
            var hasIdenticalChild = identicalSubFolders.Any();
            if (hasIdenticalChild)
                identicalChild = identicalSubFolders.First();
            return hasIdenticalChild;
        }

        public static void CreateIfNotExists(this DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
                return;
            if (Directory.Exists(directoryInfo.FullName))
                return;

            directoryInfo.Create();
        }
    }
}
