﻿using System.IO;
using CSharp.Basics.IO;
using CSharp.Basics.SevenZip;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.IOx;

namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
    public class ZipAndMoveToArchiveFolder : Step<ArchiveEventArgs>
    {
        protected override void InnerInvoke(object sender, ArchiveEventArgs args)
        {
            Log.As.Info("Zipping project...");

            var zipFileInfo = args.ProjectSettings.ProjectFolder.CombineTo<FileInfo>(args.ArchiveName);
            var zipFile = new SevenZipFile(zipFileInfo);
            zipFile.ZipContent(args.ProjectSettings.ProjectFolder.Directory);

            Log.As.Info("Moving archive to archive folder...");
            Robocopy.Move(zipFile.File, new DirectoryInfo(Services.UserPreferences.Properties.ArchiveFolder));
        }
    }
}
