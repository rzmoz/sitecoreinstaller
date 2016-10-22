using System;

namespace SitecoreInstaller.Databases
{
    public abstract class DbConnectionString
    {
        
        protected DbConnectionString(string name, string value, DbType dbType)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (value == null) throw new ArgumentNullException(nameof(value));
            Name = name;
            Value = value;
            DbType = dbType;
        }

        public string Name { get; }
        public string Value { get; }
        public DbType DbType { get; }

        public override string ToString()
        {
            return Value;
        }
    }
}
