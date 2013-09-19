using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.Database
{
    public class ConnectionStringFactory
    {
        public IConnectionString Create(string connectionString)
        {
            IConnectionString con = new MongoDbConnectionString { Value = connectionString };
            if (con.IsValid())
                return con;

            con = new MsSqlConnectionString { Value = connectionString };
            if (con.IsValid())
                return con;

            throw new NotSupportedException("The connectionstring is not supported:" + connectionString);
        }

        public IConnectionString Create(SqlSettings parameters, ConnectionStringName connectionStringName)
        {
            return new MsSqlConnectionString(parameters, connectionStringName);
        }
    }
}
