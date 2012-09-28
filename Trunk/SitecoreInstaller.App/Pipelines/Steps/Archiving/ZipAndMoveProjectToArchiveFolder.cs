using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
    using System.IO;

    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Framework.Archiving;
    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.IO;

    public class ZipAndMoveProjectToArchiveFolder : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Log.As.Info("Zipping project...");
            var zipFileInfo =
                Services.ProjectSettings.ProjectFolder.CombineTo<FileInfo>(
                    Services.ProjectSettings.ProjectName + "_rev." + DateTime.Now.ToString("yyyyMMddhhmmss") + ".zip");
            var zipFile = new SevenZipFile(zipFileInfo);
            zipFile.ZipContent(Services.ProjectSettings.ProjectFolder.Directory);

            Log.As.Info("Moving archive to archive folder...");
            zipFile.File.MoveTo(new DirectoryInfo(UserSettings.Default.ArchiveFolder), true);
        }
    }
}
