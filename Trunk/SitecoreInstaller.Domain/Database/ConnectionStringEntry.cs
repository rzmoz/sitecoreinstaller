using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Database
{
    public class ConnectionStringEntry
    {
        public ConnectionStringEntry()
            : this(string.Empty, string.Empty)
        {
        }

        public ConnectionStringEntry(string entryName, string connectionString)
        {
            Name = new ConnectionStringName();
            if (entryName != null)
                Name = new ConnectionStringName(" _" + entryName);
            ConnectionString = connectionString ?? string.Empty;
        }

        public ConnectionStringEntry(SqlSettings parameters, ConnectionStringName connectionStringName)
        {
            Name = connectionStringName;
            ConnectionString = string.Format(_ConnectionStringFormat, parameters.Login, parameters.Password, parameters.InstanceName, connectionStringName);
        }
        public ConnectionStringName Name { get; set; }
        public string ConnectionString { get; set; }

        public override string ToString()
        {
            return string.Format(_ConnectionStringEntryFormat, Name.DatabasePart.ToLowerInvariant(), ConnectionString);
        }
        public string ToInsertString()
        {
            return string.Format(_ConnectionStringInsertEntryFormat, Name.DatabasePart.ToLowerInvariant(), ConnectionString);
        }
        public string ToReplaceString()
        {
            return string.Format(_ConnectionStringReplaceEntryFormat, Name.DatabasePart.ToLowerInvariant(), ConnectionString);
        }

        private const string _ConnectionStringEntryFormat = @"<add name=""{0}"" connectionString=""{1}"" />
";
        private const string _ConnectionStringInsertEntryFormat = @"<add name=""{0}"" connectionString=""{1}"" xdt:Transform=""Insert"" xdt:Locator=""Match(name)""  />
";
        private const string _ConnectionStringReplaceEntryFormat = @"<add name=""{0}"" connectionString=""{1}"" xdt:Transform=""Replace"" xdt:Locator=""Match(name)""/>
";
        private const string _ConnectionStringFormat = "user id={0};password={1};Data Source={2};Database={3}";
    }
}
