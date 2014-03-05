using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Azure;
using SitecoreInstaller.Azure.Packaging.Databases;

namespace SitecoreInstaller.App.Pipelines.Steps.Azure
{
    public class PrepDatabases : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            args.ProjectSettings.ProjectFolder.Website.AppConfig.ConnectionStringsConfigFile.InitFromFile();

            var databasesToPrep = new[] { 
                SitecoreDatabase.Core.ToString(), 
                SitecoreDatabase.Master.ToString(), 
                SitecoreDatabase.Web.ToString(), 
                SitecoreDatabase.Analytics.ToString() };

            Parallel.ForEach(databasesToPrep, (dbName) => PrepDatabase(dbName, args));
        }

        private void PrepDatabase(string key, PipelineApplicationEventArgs args)
        {
            var conStringEntry = args.ProjectSettings.ProjectFolder.Website.AppConfig.ConnectionStringsConfigFile[key];
            AzureServices.Sql.PrepDatabaseForBacpac(conStringEntry);
        }
    }
}
