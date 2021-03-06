﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using CSharp.Basics.IO;
using CSharp.Basics.Sys.Tasks;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Framework.IOx
{
    public static class IoService
    {
        public static IEnumerable<string> GetUniqueFileNames(this DirectoryInfo folder)
        {
            if (Directory.Exists(folder.FullName) == false)
                yield break;

            var uniqueFileNames = new HashSet<string>();

            foreach (var file in folder.GetFiles())
            {
                var processedName = file.NameWithoutExtension().ToLowerInvariant();
                if (uniqueFileNames.Contains(processedName) == false)
                {
                    uniqueFileNames.Add(processedName);
                    yield return file.NameWithoutExtension();
                }
            }
        }

        public static void CreateWithLog(this DirectoryInfo folder)
        {
            if (Directory.Exists(folder.FullName))
                Log.As.Debug("Folder already exist: '{0}'", folder.FullName);
            else
            {
                folder.Create();
                Log.As.Debug("Folder created: '{0}'", folder.FullName);
            }
        }

        public static void DeleteWithLog(this DirectoryInfo folder, OnFail onFail = OnFail.LogError)
        {
            const int maxTries = 15;
            if (folder.Exists() == false)
                return;

            var succeeded = Do.This(() =>
            {
                try
                {
                    folder.Delete(true);
                    Log.As.Debug("Folder deleted: '{0}'", folder.FullName);
                }
                catch (DirectoryNotFoundException)
                {/*happens when the files are released and deleted between retries */       }
                catch (UnauthorizedAccessException e)
                { Log.As.Debug("Waiting for release of file handles due to UnauthorizedAccessException...{0}", e.ToString()); }
                catch (IOException e)
                { Log.As.Debug("Waiting for release of file handles due to IOException...{0}", e.ToString()); }
                catch (SecurityException e)
                { Log.As.Debug("Waiting for release of file handles due to SecurityException...{0}", e.ToString()); }
            }).Until(() => !folder.Exists(), maxTries);

            if (!succeeded)
            {
                if (onFail == OnFail.Ignore)
                    return;

                if (folder.Exists())
                    Log.As.Error("Gave up waiting. Please delete folder manually: '{0}'", folder.FullName);
            }
        }
        
        public static bool TryBackup(this FileInfo file)
        {
            Log.As.Debug("Trying to backup file: {0}", file.FullName);

            if (!File.Exists(file.FullName))
            {
                Log.As.Debug("File not found for backup: {0}", file.FullName);
                return false;
            }

            string backupFileName;
            do
            {
                backupFileName = GetBackupFileName(file);
            }
            while (File.Exists(backupFileName));

            file.CopyTo(backupFileName);
            Log.As.Debug("Existing file was backed up to :" + backupFileName);
            return true;
        }

        private static string GetBackupFileName(FileInfo file)
        {
            if (file == null) { throw new ArgumentNullException("file"); }

            var backupExtension = "." + DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss") + ".backup";
            return file.FullName + backupExtension;
        }

        public static IEnumerable<DirectoryInfo> GetSubFolders(this DirectoryInfo rootFolder, string subfoldersDescription = "")
        {
            if (rootFolder == null)
                yield break;

            //Log.This.Debug("Getting {0}s", subfoldersDescription);
            if (!rootFolder.Exists)
            {
                Log.As.Error(subfoldersDescription + " folder not found: {0}", rootFolder.FullName);
                yield break;
            }

            foreach (var dir in rootFolder.GetDirectories(".", SearchOption.TopDirectoryOnly))
            {
                Log.As.Debug(subfoldersDescription + "s found: {0}", dir.Name);
                yield return dir;
            }
        }
        public static void CopyTo(this DirectoryInfo source, Folder target, DirCopyOptions dirCopyOptions)
        {
            source.CopyTo(target.Directory, dirCopyOptions);
        }
        
        public static void CopyFlattenedTo(this DirectoryInfo source, DirectoryInfo target, string searchPattern = "*")
        {
            Log.As.Debug("Flattening '{0}' files in '{1}'...", searchPattern, target.FullName);
            if (Directory.Exists(source.FullName) == false)
            {
                Log.As.Debug("Source '{0}' not found. Aborting", source.FullName, target.FullName);
                return;
            }

            // Check if the target directory exists, if not, create it.
            target.CreateIfNotExists();

            // Copy each file into it’s new directory.
            Parallel.ForEach(source.GetFiles(searchPattern, SearchOption.AllDirectories), file =>
                                                                                                {
                                                                                                    var targetFile = target.CombineTo<FileInfo>(file.Name);
                                                                                                    file.CopyTo(targetFile.FullName, true);
                                                                                                });
        }
    }
}
