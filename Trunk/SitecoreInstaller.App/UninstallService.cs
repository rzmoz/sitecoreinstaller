using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SitecoreInstaller.Domain.Batch;
using SitecoreInstaller.Framework.Messaging;

namespace SitecoreInstaller.App
{
    public class UninstallService : SitecoreInstallerService
    {
        public event EventHandler DeletedProjectFolder;

        [Step(1)]
        public void StopApplication(object sender, EventArgs e)
        {
            Services.IisManagement.StopApplication(Services.AppSettings.IisSiteName);
        }
        [Step(2)]
        public void DetachDatabases(object sender, EventArgs e)
        {
            Services.Sql.DetachDatabases(Services.AppSettings.DetachScriptPath, Services.AppSettings.Sql);
        }
        [Step(3)]
        public void DeleteIisSiteAndAppPool(object sender, EventArgs e)
        {
            Services.IisManagement.DeleteApplication(Services.AppSettings.IisSiteName);
        }
        [Step(4)]
        public void DeleteSiteNameFromHostFile(object sender, EventArgs e)
        {
            Services.HostFile.RemoveHostName(Services.AppSettings.IisSiteName);
        }
        [Step(5)]
        public void DeleteRuntimeServices(object sender, EventArgs e)
        {
            Services.Website.DeleteRuntimeServices(Services.AppSettings.WebSiteFolders.WebSiteFolder);
        }

        [StepPrecondition(6, RunMode = RunMode.UiOnly)]
        public bool DeleteProjectFolderDialog(string @null)
        {
            return !Services.Dialogs.UserAccept("Do you want to keep '{0}'? (Saying no will delete it forever!)", Services.AppSettings.ProjectName);
        }
        [Step(6)]
        public void DeleteProject(object sender, EventArgs e)
        {
            Services.Website.DeleteProjectFolder(Services.AppSettings.ProjectFolder);
            if (DeletedProjectFolder != null)
                DeletedProjectFolder(this, new EventArgs());
        }
    }
}
