using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.Domain.Pipelines;

    public class ReAttachPipeline:SitecoreInstallerPipeline
    {
        public ReAttachPipeline(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        [Step(1)]
        public void AttachDatabases(object sender, EventArgs e)
        {
            var databases = Services.Sql.GetDatabases(AppSettings.WebsiteFolders.DatabaseFolder, AppSettings.ProjectName.Value);
            foreach (var sqlDatabase in databases)
                sqlDatabase.Attach(AppSettings.Sql);
        }
        [Step(2)]
        public void AddSiteNameToHostFile(object sender, EventArgs e)
        {
            Services.HostFile.AddHostName(AppSettings.IisSiteName);
        }
        [Step(3)]
        public void CreateIisSiteAndAppPool(object sender, EventArgs e)
        {
            Services.IisManagement.CreateApplication(AppSettings.AppPool, AppSettings.WebsiteFolders.WebSiteFolder, AppSettings.WebsiteFolders.IisLogFilesFolder);
        }
    }
}
