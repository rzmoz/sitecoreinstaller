using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.Database
{
    public class MsSqlConnectionString : BaseConnectionString
    {
        private const string _connectionStringFormat = "user id={0};password={1};Data Source={2};Database={3}";
        
        public MsSqlConnectionString()
        {
        }

        public MsSqlConnectionString(SqlSettings parameters, ConnectionStringName connectionStringName)
        {
            Value = string.Format(_connectionStringFormat, parameters.Login, parameters.Password, parameters.InstanceName, connectionStringName);
        }
    }
}
