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
        private const string _connectionStringIntegratedSecurityFormat = @"Data Source={0};Initial Catalog={1};Integrated Security=SSPI;";

        public MsSqlConnectionString()
        {
        }

        public MsSqlConnectionString(SqlSettings parameters, ConnectionStringName connectionStringName)
        {
            if (parameters.UseIntegratedSecurity)
                Value = string.Format(_connectionStringIntegratedSecurityFormat, parameters.InstanceName, connectionStringName);
            else
                Value = string.Format(_connectionStringFormat, parameters.Login, parameters.Password, parameters.InstanceName, connectionStringName);
        }
    }
}
