using System.IO;
using SitecoreInstaller.Framework.Archiving;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
    public class ZipAndMoveToArchiveFolder : Step<ArchiveEventArgs>
    {
        protected override void InnerInvoke(object sender, ArchiveEventArgs args)
        {
            Log.ToApp.Info("Zipping project...");

            var zipFileInfo = args.ProjectSettings.ProjectFolder.CombineTo<FileInfo>(args.ArchiveName);
            var zipFile = new SevenZipFile(zipFileInfo);
            zipFile.ZipContent(args.ProjectSettings.ProjectFolder.Directory);

            Log.ToApp.Info("Moving archive to archive folder...");
            Robocopy.Move(zipFile.File, new DirectoryInfo(Services.UserPreferences.Properties.ArchiveFolder));
        }
    }
}
