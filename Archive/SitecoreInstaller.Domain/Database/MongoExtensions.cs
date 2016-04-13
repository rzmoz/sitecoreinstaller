using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace SitecoreInstaller.Domain.Database
{
    internal static class MongoExtensions
    {
        public static MongoUrl ToMongoUrl(this string url, int connectTimeoutInSeconds)
        {
            var mongoUrlBuilder = new MongoUrlBuilder(url)
            {
                ConnectTimeout = TimeSpan.FromSeconds(connectTimeoutInSeconds)
            };
            return new MongoUrl(mongoUrlBuilder.ToString());
        }

        public static MongoDatabase ToMongoDatabase(this MongoUrl mongoUrl)
        {
            var server = mongoUrl.GetMongoServer();
            var dbSettings = new MongoDatabaseSettings();
            return new MongoDatabase(server, mongoUrl.DatabaseName, dbSettings);
        }

        public static MongoServer GetMongoServer(this MongoUrl mongoUrl)
        {
            var client = new MongoClient(mongoUrl);
            return client.GetServer();
        }
    }

}
