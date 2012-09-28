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
                    Services.ProjectSettings.ProjectName + DateTime.Now.ToString("yyyyMMddhhmmssSSS") + ".zip");
            var zipFile = new SevenZipFile(zipFileInfo);
            zipFile.ZipContent(Services.ProjectSettings.ProjectFolder.Directory);
        }
    }
}
