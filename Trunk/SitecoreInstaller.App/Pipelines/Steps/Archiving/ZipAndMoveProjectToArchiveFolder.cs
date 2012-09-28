using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
    using System.IO;
    using System.Windows.Forms;

    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Archiving;
    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.IO;

    public class ZipAndMoveProjectToArchiveFolder : Step
    {
        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            Log.As.Info("Zipping project...");

            var archiveName = Services.ProjectSettings.ProjectName + "_rev." + DateTime.Now.ToString("yyyyMMdd");
            string userInput = archiveName;
            if (args.Dialogs == Dialogs.On)
            {
                if (Services.Dialogs.InputBox("Enter archive name", "Archive name", ref userInput) == DialogResult.OK && userInput.Length > 0)
                    archiveName = userInput;
            }
            var zipFileInfo = Services.ProjectSettings.ProjectFolder.CombineTo<FileInfo>(archiveName);
            var zipFile = new SevenZipFile(zipFileInfo);
            zipFile.ZipContent(Services.ProjectSettings.ProjectFolder.Directory);

            Log.As.Info("Moving archive to archive folder...");
            var robocopy = new Robocopy();
            robocopy.Move(zipFile.File, new DirectoryInfo(UserSettings.Default.ArchiveFolder));
        }
    }
}
