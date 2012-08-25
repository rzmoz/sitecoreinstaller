using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using System.IO;

    public class CheckProjectDoesNotExixts : Precondition
    {
        public CheckProjectDoesNotExixts(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        public override bool Evaluate(object sender, EventArgs args)
        {
            var appSettings = GetAppSettings();
            if (Directory.Exists(appSettings.WebsiteFolders.ProjectFolder.FullName) == false)
                return true;

            ErrorMessage = string.Format("Project '{0}' already exists.\r\nPlease delete first or choose anohter project name for this installation.\r\n\r\nLocation: {1}", appSettings.ProjectName, appSettings.WebsiteFolders.ProjectFolder);
            return false;
        }
    }
}
