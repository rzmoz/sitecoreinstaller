﻿using System.IO;
using SitecoreInstaller.Framework.Archiving;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
  public class ZipAndMoveToArchiveFolder : Step<ArchiveEventArgs>
  {
    protected override void InnerInvoke(object sender, ArchiveEventArgs args)
    {
      Log.This.Info("Zipping project...");

      var zipFileInfo = args.ProjectSettings.ProjectFolder.CombineTo<FileInfo>(args.ArchiveName);
      var zipFile = new SevenZipFile(zipFileInfo);
      zipFile.ZipContent(args.ProjectSettings.ProjectFolder.Directory);

      Log.This.Info("Moving archive to archive folder...");
      var robocopy = new Robocopy();
      robocopy.Move(zipFile.File, new DirectoryInfo(Services.UserPreferences.Properties.ArchiveFolder));
    }
  }
}
