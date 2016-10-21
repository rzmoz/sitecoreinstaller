using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using NLog;


namespace SitecoreInstaller.Databases
{
    public class MongoService
    {
        private readonly ILogger _logger;

        public MongoService()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public string GenerateConnectionStringsDelta(MongoSettings settings, IEnumerable<ConnectionStringEntry> existingStringEntries, string projectName)
        {
            var connectionStringEntries = string.Empty;

            foreach (var mongoEntry in existingStringEntries.Where(entry => entry.ConnectionString is MongoConnectionString))
            {
                ((MongoConnectionString)mongoEntry.ConnectionString).SetProjectName(projectName);
                connectionStringEntries += mongoEntry.ToReplaceString();
            }
            var connectionStringsXdt = string.Format(ConnectionStringFormats.ConnectionStringXdtFormat, connectionStringEntries);
            _logger.Debug(connectionStringsXdt);
            return connectionStringsXdt;
        }

        public void EnsureDatabases(ConnectionStringsFile connectionStrings)
        {
            foreach (var mongoEntry in connectionStrings.Where(entry => entry.ConnectionString is MongoConnectionString))
            {
                var mongoUrl = new MongoUrl(mongoEntry.ConnectionString.Value);
                var db = mongoUrl.ToMongoDatabase();
                const string tempCollectionName = "SitecoreInstallerTempCollection";
                db.CreateCollection(tempCollectionName);
                db.DropCollection(tempCollectionName);
            }
        }
        public void DropDatabases(ConnectionStringsFile connectionStrings)
        {
            foreach (var mongoEntry in connectionStrings.Where(entry => entry.ConnectionString is MongoConnectionString))
            {
                var mongoUrl = mongoEntry.ConnectionString.Value.ToMongoUrl(3);
                try
                {
                    var db = mongoUrl.ToMongoDatabase();
                    db.DropCollection(mongoUrl.DatabaseName);
                }
                catch (MongoConnectionException e)
                {
                    _logger.Error($"Couldn't drop mongo db: '{mongoUrl.DatabaseName}':" + e);
                }
            }
        }
    }
}
