using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.Database
{
    public class MongoDbConnectionString : BaseConnectionString
    {
        private const string _protocol = @"mongodb://";
        private const string _connectionStringFormat = "mongodb://{0}:{1}/{2}";
        private const string _connectionStringWithUsernameAndPasswordFormat = "mongodb://{0}:{1}@{2}:{3}/{4}";

        public MongoDbConnectionString()
        {
        }

        public MongoDbConnectionString(MongoDbSettings settings, string dbName)
        {
            if (string.IsNullOrEmpty(settings.Username) || string.IsNullOrEmpty(settings.Password))
                Value = string.Format(_connectionStringFormat, settings.Endpoint, settings.Port, dbName);
            else
                Value = string.Format(_connectionStringWithUsernameAndPasswordFormat, settings.Username, settings.Password, settings.Endpoint, settings.Port, dbName);
        }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Value))
                return false;
            return Value.ToLowerInvariant().StartsWith(_protocol);
        }
    }
}
