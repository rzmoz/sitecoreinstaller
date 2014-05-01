using System.Collections.Generic;
using System.IO;
using CSharp.Basics.IO;
using System;

namespace SitecoreInstaller.Framework.IOx
{
    public static class DirectoryInfoExtensions
    {
        public static DirectoryInfo ToDirectoryInfo(this string dir)
        {
            if (dir == null) { throw new ArgumentNullException("dir"); }
            return new DirectoryInfo(dir);
        }

        public static void Clean(this DirectoryInfo dir, OnFail onFail = OnFail.LogError)
        {
            dir.DeleteWithLog(onFail);
            dir.CreateIfNotExists();
        }

        public static T Combine<T>(this Folder folder, params T[] paths) where T : FileSystemInfo
        {
            return folder.Directory.Combine(paths);
        }

        public static T CombineTo<T>(this Folder folder, params string[] paths) where T : FileSystemInfo
        {
            return folder.Directory.CombineTo<T>(paths);
        }

        public static IEnumerable<FileInfo> GetFiles(this Folder folder, FileType fileType)
        {
            return folder.Directory.GetFiles(fileType.GetAllSearchPattern);
        }

        public static IEnumerable<FileInfo> GetFiles(this DirectoryInfo directory, FileType fileType)
        {
            return directory.GetFiles(fileType.GetAllSearchPattern);
        }

        public static IEnumerable<FileInfo> GetFiles(this DirectoryInfo directory, FileType fileType, SearchOption searchOption)
        {
            return directory.GetFiles(fileType.GetAllSearchPattern, searchOption);
        }

        public static void DeleteIfExists(this DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
                return;
            if (Directory.Exists(directoryInfo.FullName))
                directoryInfo.Delete();
        }

        public static void CopyTo(this IEnumerable<DirectoryInfo> directoryInfos, Folder target)
        {
            directoryInfos.CopyTo(target.Directory);
        }

        public static void CopyTo(this IEnumerable<DirectoryInfo> directoryInfos, DirectoryInfo target)
        {
            foreach (var dir in directoryInfos)
            {
                var targetFolder = target.Combine(dir);
                dir.CopyTo(targetFolder, DirCopyOptions.IncludeSubDirectories);
            }
        }

        public static void GrantFullControl(this Folder folder, string username)
        {
            folder.Directory.GrantFullControl(username);
        }
    }
}
