using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using NLog;

namespace SitecoreInstaller.Databases
{
    public class MongoDbConnector
    {
        private readonly ILogger _logger;

        public MongoDbConnector()
        {
            _logger = LogManager.GetLogger(nameof(MongoDbConnector));
        }

        public bool TestConnection(MongoSettings settings)
        {
            try
            {
                var db = GetDatabase("SitecoreInstallerVerifyConnectionDatabaseFeelFreeToDeleteMe", settings);
                const string testCollectionName = "test";
                if (db.CollectionExists(testCollectionName))
                    DropCollection(db, testCollectionName);
                db.CreateCollection(testCollectionName);
                DropCollection(db, testCollectionName);
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }

        public void DropCollection(IMongoDatabase db, string colName)
        {
            if (db == null) throw new ArgumentNullException(nameof(db));
            if (colName == null) throw new ArgumentNullException(nameof(colName));
            try
            {
                db.DropCollection(colName);
                _logger.Error($"Mongo collection dropped: {colName}");
            }
            catch (MongoConnectionException e)
            {
                _logger.Error($"Drop mongo collection {colName} failed: " + e);
            }
        }

        public string GenerateConnectionStringsXdt(MongoSettings settings, IEnumerable<ConnectionStringEntry> existingStringEntries, string projectName)
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

        public void DropCollections(ConnectionStringsFile connectionStrings)
        {
            foreach (var mongoEntry in connectionStrings.Where(entry => entry.ConnectionString is MongoConnectionString))
            {
                var mongoUrl = ((MongoConnectionString)mongoEntry.ConnectionString).MongoUrl;
                try
                {
                    var db = GetDatabase(mongoEntry.Name.ToString(), mongoUrl);
                    db.DropCollection(mongoUrl.DatabaseName);
                }
                catch (MongoConnectionException e)
                {
                    _logger.Error($"Couldn't drop mongo db: '{mongoUrl.DatabaseName}':" + e);
                }
            }
        }

        public IMongoClient GetClient(MongoUrl url) => new MongoClient(url);
        public IMongoDatabase GetDatabase(string name, MongoUrl url) => GetClient(url).GetDatabase(name);
        public IMongoClient GetClient(MongoSettings settings) => new MongoClient(new MongoConnectionString(settings).Value);
        public IMongoDatabase GetDatabase(string name, MongoSettings settings) => GetClient(settings).GetDatabase(name);
    }
}
