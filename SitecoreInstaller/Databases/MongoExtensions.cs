using System;
using MongoDB.Driver;

namespace SitecoreInstaller.Databases
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

        public static IMongoDatabase ToMongoDatabase(this MongoUrl mongoUrl)
        {
            var client = new MongoClient(mongoUrl);
            var dbSettings = new MongoDatabaseSettings();
            return client.GetDatabase(mongoUrl.DatabaseName, dbSettings);
        }
    }
}
