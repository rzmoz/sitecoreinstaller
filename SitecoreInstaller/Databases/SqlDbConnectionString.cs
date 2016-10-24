using System;
using System.Data.SqlClient;

namespace SitecoreInstaller.Databases
{
    public class SqlDbConnectionString : DbConnectionString
    {
        public SqlDbConnectionString(string name, SqlConnectionStringBuilder builder)
            : base(name, builder.InitialCatalog, builder.ConnectionString, DbType.Sql)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
        }
    }
}
