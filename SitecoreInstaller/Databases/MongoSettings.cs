using System;
using MongoDB.Bson;
using MongoDB.Driver;
using NLog;

namespace SitecoreInstaller.Databases
{
    public class MongoSettings
    {
        public MongoSettings()
        {
            Username = string.Empty;
            Password = string.Empty;
            Endpoint = "localhost";
            Port = 27017;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Endpoint { get; set; }
        public int Port { get; set; }

        public bool TestConnection()
        {
            try
            {
                var conStr = new MongoConnectionString(this).Value;
                var client = new MongoClient(conStr);
                var dbSettings = new MongoDatabaseSettings();
                var db = client.GetDatabase("SitecoreInstallerVerifyCredentialsDatabase", dbSettings);
                const string testCollectionName = "test";
                var filter = new BsonDocument("name", testCollectionName);
                if (db.ListCollections(new ListCollectionsOptions { Filter = filter }).Any())
                    db.DropCollection(testCollectionName);
                db.CreateCollection(testCollectionName);
                db.DropCollection(testCollectionName);
                return true;
            }
            catch (Exception e)
            {
                LogManager.GetCurrentClassLogger().Error(e);
                return false;
            }
        }
    }
}
