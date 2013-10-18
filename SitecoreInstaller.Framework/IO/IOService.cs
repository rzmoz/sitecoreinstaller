using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace SitecoreInstaller.Framework.IO
{
  using Diagnostics;

  public static class IoService
  {
    public static void WriteToDisk(this string content, FileInfo targetFile)
    {
      if (targetFile == null)
        return;

      targetFile.Directory.CreateIfNotExists();

      File.WriteAllText(targetFile.FullName, content);
      Log.This.Debug("Saved string to disk at: {0}", targetFile.FullName);
    }

    public static void WriteToDir(this string content, DirectoryInfo dir, string filename)
    {
      var file = new FileInfo(Path.Combine(dir.FullName, filename));
      WriteToDisk(content, file);
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
        Log.This.Debug("Folder already exist: '{0}'", folder.FullName);
      else
      {
        folder.Create();
        Log.This.Debug("Folder created: '{0}'", folder.FullName);
      }
    }

    public static void DeleteWithLog(this DirectoryInfo folder, OnFail onFail = OnFail.LogError)
    {
      const int retries = 15;

      if (folder.Exists() == false)
        return;

      for (var tryCount = 1; tryCount <= retries; tryCount++)
      {
        try
        {
          folder.Delete(true);
          Log.This.Debug("Folder deleted: '{0}'", folder.FullName);
        }
        catch (DirectoryNotFoundException)
        {
          //happens when the files are released and deleted between retries
          break;
        }
        catch (UnauthorizedAccessException e)
        {
          Log.This.Debug("Waiting for release of file handles due to UnauthorizedAccessException...{0}", e.ToString());
          Task.WaitAll(Task.Delay(1000));
        }
        catch (IOException e)
        {
          Log.This.Debug("Waiting for release of file handles due to IOException...{0}", e.ToString());
          Task.WaitAll(Task.Delay(1000));
        }
        catch (SecurityException e)
        {
          Log.This.Debug("Waiting for release of file handles due to SecurityException...{0}", e.ToString());
          Task.WaitAll(Task.Delay(1000));
        }
      }

      if (onFail == OnFail.Ignore)
        return;

      if (folder.Exists())
        Log.This.Error("Gave up waiting. Please delete folder manually: '{0}'", folder.FullName);
    }

    public static void ConsolidateIdenticalSubfolders(this DirectoryInfo rootFolder)
    {
      if (rootFolder == null)
        return;
      if (rootFolder.Exists() == false)
        return;

      //if folder has a sub folder with identical name, we move it up one level
      DirectoryInfo identicalSubFolder;

      if (rootFolder.TryGetIdenticallyNamedSubDir(out identicalSubFolder))
      {
        Log.This.Debug("'{0}' contains identical named subfolder. Consolidating...", identicalSubFolder.FullName);
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
      Log.This.Debug("Trying to backup file: {0}", file.FullName);

      if (!File.Exists(file.FullName))
      {
        Log.This.Debug("File not found for backup: {0}", file.FullName);
        return false;
      }

      string backupFileName;
      do
      {
        backupFileName = GetBackupFileName(file);
      }
      while (File.Exists(backupFileName));

      file.CopyTo(backupFileName);
      Log.This.Debug("Existing file was backed up to :" + backupFileName);
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
        Log.This.Error(subfoldersDescription + " folder not found: {0}", rootFolder.FullName);
        yield break;
      }

      foreach (var dir in rootFolder.GetDirectories(".", SearchOption.TopDirectoryOnly))
      {
        Log.This.Debug(subfoldersDescription + "s found: {0}", dir.Name);
        yield return dir;
      }
    }
    public static void CopyTo(this DirectoryInfo source, Folder target, DirCopyOptions dirCopyOptions)
    {
      source.CopyTo(target.Directory, dirCopyOptions);
    }
    public static void CopyTo(this DirectoryInfo source, DirectoryInfo target, DirCopyOptions dirCopyOptions)
    {
      if (Directory.Exists(source.FullName) == false)
      {
        Log.This.Warning("Source '{0}' not found. Aborting", source.FullName);
        return;
      }

      if (source.FullName.Equals(target.FullName, StringComparison.OrdinalIgnoreCase))
      {
        Log.This.Debug("Source and Target are the same '{0}'. Aborting", source.FullName);
        return;
      }

      try
      {
        target.CreateIfNotExists();

        foreach (var file in source.GetFiles())
          file.CopyTo(target, true);

        if (dirCopyOptions == DirCopyOptions.ExcludeSubDirectories)
          return;

        // Include subdirectories
        Parallel.ForEach(source.GetDirectories(), dir =>
        {
          DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(dir.Name);
          CopyTo(dir, nextTargetSubDir, dirCopyOptions);
        });
      }
      catch (IOException e)
      {
        Log.This.Debug("Fast copy failed - falling back to use robocopy\r\n{0}", e.ToString());
        target.DeleteIfExists();
        var robocopy = new Robocopy();
        robocopy.Copy(source, target, dirCopyOptions);
      }
    }

    public static void CopyFlattenedTo(this DirectoryInfo source, DirectoryInfo target, string searchPattern = "*")
    {
      Log.This.Debug("Flattening '{0}' files in '{1}'...", searchPattern, target.FullName);
      if (Directory.Exists(source.FullName) == false)
      {
        Log.This.Debug("Source '{0}' not found. Aborting", source.FullName, target.FullName);
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
