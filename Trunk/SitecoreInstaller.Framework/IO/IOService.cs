using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace SitecoreInstaller.Framework.IO
{
    using SitecoreInstaller.Framework.Diagnostics;

    using global::System.Diagnostics;
    using global::System.Diagnostics.Contracts;

    public static class IoService
    {
        public static void WriteToDisk(this string content, FileInfo targetFile)
        {
            File.WriteAllText(targetFile.FullName, content);
            Log.As.Debug("{0} saved to disk at: {1}", content, targetFile.FullName);
        }

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
        public static void DeleteWithLog(this DirectoryInfo folder)
        {
            const int retries = 10;

            try
            {
                for (var tryCount = 1; tryCount <= retries; tryCount++)
                {
                    folder.Refresh();
                    if (folder.Exists)
                    {
                        try
                        {
                            folder.Delete(true);
                            Log.As.Debug("Folder deleted: '{0}'", folder.FullName);
                        }
                        catch (DirectoryNotFoundException)
                        {
                            //happens when the files are released and deleted between retries
                            break;
                        }
                        catch (IOException)
                        {
                            Log.As.Debug("Waiting for iis to release file handles...");
                            Thread.Sleep(500);
                        }
                    }
                    else
                    {
                        //sometimes happens when folder is deleted between retries which can happen when folder handles are released after a while when deleting a site
                        Log.As.Debug("Folder doesn't exist: '{0}'", folder.FullName);
                        break;
                    }
                }

                if (Directory.Exists(folder.FullName))
                    Log.As.Warning("Gave up waiting. Please delete folder manually: '{0}'", folder.FullName);
            }
            catch (UnauthorizedAccessException e)
            {
                Log.As.Error("Unable to delete folder.\r\n{0}", e.ToString());
            }
            catch (SecurityException e)
            {
                Log.As.Error("Unable to delete folder.\r\n{0}", e.ToString());
            }
        }

        public static void ConsolidateIdenticalSubfolders(this DirectoryInfo rootFolder)
        {
            if (rootFolder == null)
                return;
            if (Directory.Exists(rootFolder.FullName) == false)
                return;

            //if folder has a sub folder with identical name, we move it up one level
            DirectoryInfo identicalSubFolder;

            if (rootFolder.TryGetIdenticallyNamedSubDir(out identicalSubFolder))
            {
                Log.As.Debug("'{0}' contains identical named subfolder. Consolidating...", identicalSubFolder.FullName);
                ConsolidateIdenticalSubfolders(identicalSubFolder);
            }

            if (rootFolder.ParentHasIdenticalName())
            {
                var robocopy = new Robocopy();
                robocopy.Move(rootFolder, rootFolder.Parent);
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
            Contract.Requires<ArgumentNullException>(file != null);

            var backupExtension = "." + DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss") + ".backup";
            return file.FullName + backupExtension;
        }

        public static IEnumerable<DirectoryInfo> GetSubFolders(this DirectoryInfo rootFolder, string subfoldersDescription = "")
        {
            if (rootFolder == null)
                yield break;

            Log.As.Debug("Getting {0}s", subfoldersDescription);
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

        public static void CopyTo(this DirectoryInfo source, DirectoryInfo target, DirCopyOptions dirCopyOptions)
        {
            if (Directory.Exists(source.FullName) == false)
            {
                Log.As.Debug("Source '{0}' not found. Aborting", source.FullName);
                return;
            }

            if (source.FullName.Equals(target.FullName, StringComparison.OrdinalIgnoreCase))
            {
                Log.As.Debug("Source and Target are the same '{0}'. Aborting", source.FullName);
                return;
            }
            var robocopy = new Robocopy();
            robocopy.Copy(source, target, dirCopyOptions);
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
