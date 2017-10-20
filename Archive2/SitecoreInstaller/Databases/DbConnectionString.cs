using System;

namespace SitecoreInstaller.Databases
{
    public abstract class DbConnectionString
    {
        protected DbConnectionString(string name, string databaseName, string value, DbType dbType)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (databaseName == null) throw new ArgumentNullException(nameof(databaseName));
            if (value == null) throw new ArgumentNullException(nameof(value));
            Name = name.ToLowerInvariant();
            DatabaseName = databaseName;
            Value = value;
            DbType = dbType;
        }

        public string Name { get; }
        public string DatabaseName { get; }
        public string Value { get; }
        public DbType DbType { get; }

        public override string ToString()
        {
            return Value;
        }
    }
}
