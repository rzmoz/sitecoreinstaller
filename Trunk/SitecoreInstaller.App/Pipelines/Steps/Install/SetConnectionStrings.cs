using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;

    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.Domain;
    using SitecoreInstaller.Domain.Database;
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Domain.Website;
    using SitecoreInstaller.Framework.System;
    using SitecoreInstaller.Framework.Xml;

    public class SetConnectionStrings : Step
    {
        public SetConnectionStrings()
        {
            AddPrecondition<CheckConnectionstringsAreSet>();
        }

        protected override void InnerInvoke(object sender, StepEventArgs args)
        {
            var connectionStrings = Services.ProjectSettings.ProjectFolder.Website.AppConfig.ConnectionStringsConfigFile;

            connectionStrings.InitFromFile();

            var existingConnectionStringNames = connectionStrings.Select(entry => entry.Name);

            if (Services.ProjectSettings.InstallType == InstallType.Full)
            {
                var databases = Services.Sql.GetDatabases(Services.ProjectSettings.ProjectFolder.Databases, Services.ProjectSettings.ProjectName);
                Services.ProjectSettings.DatabaseNames = databases.Select(db => db.LogicalName).AsUniqueStrings().Select(name => new ConnectionStringName(Services.ProjectSettings.ProjectName, name));
            }

            var connectionStringsDelta = Services.Sql.GenerateConnectionStringsDelta(Services.ProjectSettings.Sql, Services.ProjectSettings.DatabaseNames, existingConnectionStringNames);
            var transform = new XmlTransform(connectionStrings.File, connectionStringsDelta);
            transform.Run();

            //WFFM Sql-Dataprovider connection string set
            connectionStrings.InitFromFile();

            var webFormsConnectionString = connectionStrings["webforms"];

            if (webFormsConnectionString == null)
                return;

            if (File.Exists(Services.ProjectSettings.ProjectFolder.Website.AppConfig.Include.WffmConfigFile.FullName) == false)
                return;

            var formsConfigFile = new WffmConfigFile(Services.ProjectSettings.ProjectFolder.Website.AppConfig.Include.WffmConfigFile);
            if (formsConfigFile.DataProviderType == DataProviderType.Sql)
                Services.Website.CreateWffmConfigFile(webFormsConnectionString.ConnectionString, Services.ProjectSettings.ProjectFolder.Website.AppConfig.Include.WffmSqlDataproviderConfigFile);
        }
    }
}
