using System;

namespace SitecoreInstaller.Databases
{
    public class ConnectionStringEntry
    {
        public ConnectionStringEntry(string entryName, IConnectionString connectionString, DbType dbType)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));

            Name = new ConnectionStringName();
            if (entryName != null)
                Name = new ConnectionStringName(entryName);
            DbType = dbType;
            ConnectionString = connectionString;
        }

        public ConnectionStringEntry(SqlSettings parameters, ConnectionStringName connectionStringName)
        {
            Name = connectionStringName;
            ConnectionString = new SqlConnectionString(parameters, connectionStringName);
        }

        public ConnectionStringEntry(MongoSettings settings, ConnectionStringName connectionStringName)
        {
            Name = connectionStringName;
            ConnectionString = new MongoConnectionString(settings, connectionStringName);
        }

        public DbType DbType { get; }
        public ConnectionStringName Name { get; }
        public IConnectionString ConnectionString { get; }

        public override string ToString()
        {
            return string.Format(_connectionStringEntryFormat, Name.DatabasePart.ToLowerInvariant(), ConnectionString);
        }
        public string ToInsertString()
        {
            return string.Format(_connectionStringInsertEntryFormat, Name.DatabasePart.ToLowerInvariant(), ConnectionString);
        }
        public string ToReplaceString()
        {
            return string.Format(_connectionStringReplaceEntryFormat, Name.DatabasePart.ToLowerInvariant(), ConnectionString);
        }

        private const string _connectionStringEntryFormat = @"<add name=""{0}"" connectionString=""{1}"" />
";
        private const string _connectionStringInsertEntryFormat = @"<add name=""{0}"" connectionString=""{1}"" xdt:Transform=""Insert"" xdt:Locator=""Match(name)""  />
";
        private const string _connectionStringReplaceEntryFormat = @"<add name=""{0}"" connectionString=""{1}"" xdt:Transform=""Replace"" xdt:Locator=""Match(name)""/>
";
    }
}
