using System;
using MongoDB.Bson;
using MongoDB.Driver;
using NLog;

namespace SitecoreInstaller.Databases
{
    public static class MongoDbExtensions
    {
        private static readonly ILogger _logger;

        static MongoDbExtensions()
        {
            _logger = LogManager.GetLogger(nameof(MongoDbConnector));
        }

        public static bool CollectionExists(this IMongoDatabase db, string colName)
        {
            if (db == null) throw new ArgumentNullException(nameof(db));
            if (colName == null) throw new ArgumentNullException(nameof(colName));
            var filter = new BsonDocument("name", colName);
            return db.ListCollections(new ListCollectionsOptions { Filter = filter }).Any();
        }
    }
}

