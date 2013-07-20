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
    using SitecoreInstaller.Framework.Sys;
    using SitecoreInstaller.Framework.Xml;

  public class SetConnectionStrings : Step<PipelineEventArgs>
    {
        public SetConnectionStrings()
        {
            AddPrecondition<CheckConnectionstringsAreSet>();
        }

        protected override void InnerInvoke(object sender, PipelineEventArgs args)
        {
            var connectionStrings = args.ProjectSettings.ProjectFolder.Website.AppConfig.ConnectionStringsConfigFile;

            connectionStrings.InitFromFile();

            var existingConnectionStringNames = connectionStrings.Select(entry => entry.Name);

            if (args.ProjectSettings.InstallType == InstallType.Full)
            {
                var databases = Services.Sql.GetDatabases(args.ProjectSettings.ProjectFolder.Databases, args.ProjectSettings.ProjectName);
                args.ProjectSettings.DatabaseNames = databases.Select(db => db.LogicalName).AsUniqueStrings().Select(name => new ConnectionStringName(args.ProjectSettings.ProjectName, name));
            }

            var connectionStringsDelta = Services.Sql.GenerateConnectionStringsDelta(args.ProjectSettings.Sql, args.ProjectSettings.DatabaseNames, existingConnectionStringNames);
            var transform = new XmlTransform();
            transform.Transform(connectionStrings.File, connectionStringsDelta);

            //WFFM Sql-Dataprovider connection string set
            connectionStrings.InitFromFile();

            var webFormsConnectionString = connectionStrings["webforms"];

            if (webFormsConnectionString == null)
                return;

            if (File.Exists(args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.WffmConfigFile.FullName) == false)
                return;

            var formsConfigFile = new WffmConfigFile(args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.WffmConfigFile);
            if (formsConfigFile.DataProviderType == DataProviderType.Sql)
                Services.Website.CreateWffmConfigFile(webFormsConnectionString.ConnectionString, args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.WffmSqlDataproviderConfigFile);
        }
    }
}
