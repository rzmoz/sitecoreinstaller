using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;

    using SitecoreInstaller.Domain.Database;
    using SitecoreInstaller.Domain.Website;
    using SitecoreInstaller.Framework.Xml;

    public class SetConnectionStrings : Step
    {
        public SetConnectionStrings(AppSettings appSettings)
            : base(appSettings)
        {
        }

        protected override void InnerInvoke(object sender, EventArgs args)
        {
            var connectionStrings = new ConnectionStringsFile(AppSettings.ConnectionStringsConfigFile);

            connectionStrings.Init();
            var existingConnectionStringNames = connectionStrings.Select(entry => entry.Name);
            var connectionStringsDelta = Services.Sql.GenerateConnectionStringsDelta(AppSettings.Sql, AppSettings.WebsiteFolders.DatabaseFolder, AppSettings.ProjectName.Value, existingConnectionStringNames);
            var transform = new XmlTransform(connectionStrings.File, connectionStringsDelta);
            transform.Run();

            //WFFM Sql-Dataprovider connection string set
            connectionStrings.Init();

            var webFormsConnectionString = connectionStrings["webforms"];

            if (webFormsConnectionString == null)
                return;

            if (File.Exists(AppSettings.WffmConfigFile.FullName) == false)
                return;

            var formsConfigFile = new WffmConfigFile(AppSettings.WffmConfigFile);
            if (formsConfigFile.DataProviderType == DataProviderType.Sql)
                Services.Website.CreateWffmConfigFile(webFormsConnectionString.ConnectionString, AppSettings.WffmSqlDataproviderConfigFile);
        }
    }
}
