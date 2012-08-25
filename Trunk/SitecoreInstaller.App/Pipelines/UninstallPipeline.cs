using System;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using System.Collections.Generic;

    using SitecoreInstaller.App.Pipelines.Preconditions;

    public class UninstallPipeline : SitecoreInstallerPipeline
    {
        public UninstallPipeline(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        public override void Init()
        {
            //Must Init base first to get appsettings!
            base.Init();
            var preconditions = new List<IPrecondition>
                {
                    new CheckWritePermissionToHostFile(AppSettings),
                };

            preconditions.AddRange(Preconditions);
            Preconditions = preconditions;
        }

        [Step(1)]
        public void StopApplication(object sender, EventArgs e)
        {
            Services.IisManagement.StopApplication(AppSettings.IisSiteName);
        }
        [Step(2)]
        public void DetachDatabases(object sender, EventArgs e)
        {
            var databases = Services.Sql.GetDatabases(AppSettings.WebsiteFolders.DatabaseFolder, AppSettings.ProjectName.Value);
            foreach (var sqlDatabase in databases)
                sqlDatabase.Detach(AppSettings.Sql);
        }
        [Step(3)]
        public void DeleteIisSiteAndAppPool(object sender, EventArgs e)
        {
            Services.IisManagement.DeleteApplication(AppSettings.IisSiteName);
        }
        [Step(4)]
        public void DeleteSiteFromHostFile(object sender, EventArgs e)
        {
            Services.HostFile.RemoveHostName(AppSettings.IisSiteName);
        }
        [Step(5)]
        public void DeleteRuntimeServices(object sender, EventArgs e)
        {
            Services.Website.DeleteRuntimeServices(AppSettings.WebsiteFolders.WebSiteFolder);
        }

        [StepPrecondition(6, Run = Run.OnlyInUi)]
        public bool DeleteProjectFolderDialog(string @null)
        {
            return !Services.Dialogs.UserAccept("Do you want to keep '{0}'? (Saying no will delete it forever!)", AppSettings.ProjectName.Value);
        }
        [Step(6)]
        public void DeleteProject(object sender, EventArgs e)
        {
            Services.Website.DeleteProjectFolder(AppSettings.WebsiteFolders.ProjectFolder);
            
        }
    }
}
