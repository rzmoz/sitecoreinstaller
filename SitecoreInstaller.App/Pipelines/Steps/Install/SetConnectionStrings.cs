using System.IO;
using System.Linq;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.Database;
using SitecoreInstaller.Domain.Website;
using SitecoreInstaller.Framework.Sys;
using SitecoreInstaller.Framework.Xml;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class SetConnectionStrings : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            if (args.ProjectSettings.InstallType == InstallType.Client)
                return;

            var connectionStrings = args.ProjectSettings.ProjectFolder.Website.AppConfig.ConnectionStringsConfigFile;

            connectionStrings.InitFromFile();

            if (args.ProjectSettings.InstallType == InstallType.Full)
            {
                var databases = Services.Sql.GetDatabases(args.ProjectSettings.ProjectFolder.Databases, args.ProjectSettings.ProjectName);
                args.ProjectSettings.DatabaseNames = databases.Select(db => db.LogicalName).AsUniqueStrings().Select(name => new ConnectionStringName(args.ProjectSettings.ProjectName, name));
            }

            var sqlDelta = Services.Sql.GenerateConnectionStringsDelta(args.ProjectSettings.Sql, args.ProjectSettings.DatabaseNames, connectionStrings);

            XmlTransform.Transform(connectionStrings.File, sqlDelta);

            //mongo
            connectionStrings.InitFromFile();

            var mongoDelta = Services.Mongo.GenerateConnectionStringsDelta(args.ProjectSettings.Mongo, connectionStrings, args.ProjectSettings.ProjectName);

            XmlTransform.Transform(connectionStrings.File, mongoDelta);

            //WFFM Sql-Dataprovider connection string set
            connectionStrings.InitFromFile();

            var webFormsConnectionString = connectionStrings["webforms"];

            if (webFormsConnectionString == null)
                return;

            if (File.Exists(args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.WffmConfigFile.FullName) == false)
                return;

            var formsConfigFile = new WffmConfigFile(args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.WffmConfigFile);
            if (formsConfigFile.DataProviderType == DataProviderType.Sql)
                Services.Website.CreateWffmConfigFile(webFormsConnectionString.ConnectionString.Value, args.ProjectSettings.ProjectFolder.Website.AppConfig.Include.WffmSqlDataproviderConfigFile);
        }
    }
}
