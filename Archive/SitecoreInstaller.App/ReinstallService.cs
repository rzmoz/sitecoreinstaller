using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SitecoreInstaller.Domain.Batch;
using SitecoreInstaller.Framework.Messaging;

namespace SitecoreInstaller.App
{
    public class ReinstallService : SitecoreInstallerService
    {
        [Step(1)]
        public void AttachDatabases(object sender, EventArgs e)
        {
            Services.Sql.AttachDatabases(Services.AppSettings.AttachScriptPath, Services.AppSettings.Sql);
        }
        [Step(2)]
        public void AddSiteNameToHostFile(object sender, EventArgs e)
        {
            Services.HostFile.AddHostName(Services.AppSettings.IisSiteName);
        }
        [Step(3)]
        public void CreateIisSiteAndAppPool(object sender, EventArgs e)
        {
            Services.IisManagement.CreateApplication(Services.AppSettings.AppPool, Services.AppSettings.WebSiteFolders.WebSiteFolder);
        }
        [Step(4)]
        public void WarmUpSite(object sender, EventArgs e)
        {
            Services.Website.WarmUpSite(Services.AppSettings.IisSiteName);
        }
        [Step(5)]
        public void OpenSitecore(object sender, EventArgs e)
        {
            Services.Website.OpenSitecore(Services.AppSettings.IisSiteName, Services.AppSettings.WebSiteFolders.WebSiteFolder);
        }
    }

}
