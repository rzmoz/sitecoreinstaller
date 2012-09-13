using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.IO
{
    using global::System.IO;

    public static class FileSystemInfoExtensions
    {
        public static string NameWithoutExtension(this FileSystemInfo fileSystemInfo)
        {
            if (fileSystemInfo == null)
                return string.Empty;

            if (fileSystemInfo.Extension.Length == 0)
                return fileSystemInfo.Name;

            if(fileSystemInfo is DirectoryInfo)
                return fileSystemInfo.Name;

            var extensionIndex = fileSystemInfo.Name.LastIndexOf(fileSystemInfo.Extension);
            return fileSystemInfo.Name.Remove(extensionIndex);
        }
        public static string FullNameWithoutExtension(this FileSystemInfo fileSystemInfo)
        {
            if (fileSystemInfo == null)
                return string.Empty;

            if (fileSystemInfo.Extension.Length == 0)
                return fileSystemInfo.FullName;

            if (fileSystemInfo is DirectoryInfo)
                return fileSystemInfo.FullName;

            var extensionIndex = fileSystemInfo.FullName.LastIndexOf(fileSystemInfo.Extension);
            return fileSystemInfo.FullName.Remove(extensionIndex);
        }
        public static bool ExistsInDir(this FileSystemInfo fileSystemInfo, DirectoryInfo dir)
        {
            if (dir == null)
                return false;
            if (fileSystemInfo == null)
                return false;
            return File.Exists(Path.Combine(dir.FullName, fileSystemInfo.Name));
        }
        public static bool Exists(this FileSystemInfo fileSystemInfo )
        {
            if (fileSystemInfo == null)
                return false;
            return Directory.Exists(fileSystemInfo.FullName);
        }
    }
}
