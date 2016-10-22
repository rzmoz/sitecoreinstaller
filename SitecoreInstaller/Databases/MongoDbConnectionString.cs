using System;
using MongoDB.Driver;

namespace SitecoreInstaller.Databases
{
    public class MongoDbConnectionString : DbConnectionString
    {
        
        public MongoDbConnectionString(string name, MongoUrl mongoUrl) : base(name, mongoUrl.ToString(), DbType.Mongo)
        {
            if (mongoUrl == null) throw new ArgumentNullException(nameof(mongoUrl));
            MongoUrl = mongoUrl;
        }

        public MongoUrl MongoUrl { get; }
    }
}
