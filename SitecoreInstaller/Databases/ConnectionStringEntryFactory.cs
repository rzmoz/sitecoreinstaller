using System;

namespace SitecoreInstaller.Databases
{
    public class ConnectionStringEntryFactory
    {
        public ConnectionStringEntry Create(string name, string connectionString)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            if (connectionString.ToLower().Contains("mongodb://"))
            {
                return new ConnectionStringEntry(name, new MongoConnectionString { Value = connectionString }, DbType.Mongo);
            }
            if (connectionString.ToLower().Contains("Data Source="))
            {
                return new ConnectionStringEntry(name, new SqlConnectionString { Value = connectionString }, DbType.Sql);
            }
            return new ConnectionStringEntry(name, null, DbType.Unknown);
        }
    }
}
