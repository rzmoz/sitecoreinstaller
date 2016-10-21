using System;

namespace SitecoreInstaller.Databases
{
    public class ConnectionStringFactory
    {
        public IConnectionString Create(string connectionString)
        {
            IConnectionString con = new MongoConnectionString { Value = connectionString };
            if (con.IsValid())
                return con;

            con = new SqlConnectionString { Value = connectionString };
            if (con.IsValid())
                return con;

            throw new NotSupportedException("The connectionstring is not supported:" + connectionString);
        }

        public IConnectionString Create(SqlSettings parameters, ConnectionStringName connectionStringName)
        {
            return new SqlConnectionString(parameters, connectionStringName);
        }
    }
}
