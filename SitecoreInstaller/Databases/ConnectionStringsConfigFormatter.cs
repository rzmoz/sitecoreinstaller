using System.Collections.Generic;
using System.Text;

namespace SitecoreInstaller.Databases
{
    public class ConnectionStringsConfigFormatter
    {
        private const string _connectionStringEntryFormat = @"<add name=""{0}"" connectionString=""{1}"" />";

        private const string _connectionStringDotConfigFormat = @"<?xml version=""1.0"" encoding=""utf-8""?>
<connectionStrings>
    <!-- 
    Sitecore connection strings.
    All database connections for Sitecore are configured here.
  -->
{0}
</connectionStrings>";
        public string ToConfigFileString(IEnumerable<DbConnectionString> connectionStrings)
        {
            var entries = new StringBuilder();
            foreach (var dbConnectionString in connectionStrings)
                entries.AppendLine(ToConfigFileString(dbConnectionString));

            return string.Format(_connectionStringDotConfigFormat, entries.ToString());
        }

        public string ToConfigFileString(DbConnectionString dbConnectionString)
        {
            return string.Format(_connectionStringEntryFormat, dbConnectionString.Name.ToLowerInvariant(), dbConnectionString.Value);
        }
    }
}
