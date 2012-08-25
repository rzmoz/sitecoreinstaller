using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using System.IO;

    public class CheckProjectDoesNotExixts : Precondition
    {
        public CheckProjectDoesNotExixts(AppSettings appSettings)
            : base(appSettings)
        {
        }

        public override bool Evaluate(object sender, EventArgs args)
        {
            if (Directory.Exists(AppSettings.WebsiteFolders.ProjectFolder.FullName) == false)
                return true;

            ErrorMessage = string.Format("Project '{0}' already exists.\r\nPlease delete first or choose anohter project name for this installation.\r\n\r\nLocation: {1}", AppSettings.ProjectName, AppSettings.WebsiteFolders.ProjectFolder);
            return false;
        }
    }
}
