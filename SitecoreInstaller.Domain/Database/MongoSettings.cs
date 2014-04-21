using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Domain.Database
{
    public class MongoSettings
    {
        public MongoSettings()
        {
            InstallType = DbInstallType.Auto;
            Username = string.Empty;
            Password = string.Empty;
            Endpoint = "localhost";
            Port = 27017;
        }

        public DbInstallType InstallType { get; set; }
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
                var server = client.GetServer();
                server.Ping();
                var dbSettings = new MongoDatabaseSettings();
                var db = new MongoDatabase(server, "SitecoreInstallerVerifyCredentialsDatabase", dbSettings);
                const string testCollectionName = "test";
                if (db.CollectionExists(testCollectionName))
                    db.DropCollection(testCollectionName);
                db.CreateCollection(testCollectionName);
                db.Drop();
                return true;
            }
            catch (Exception e)
            {
                Log.ToApp.Debug(e.ToString());
                Log.ToApp.Error(e.Message);
                return false;
            }
        }
    }
}
