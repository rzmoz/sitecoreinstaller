using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Framework.Databases
{
    public class SqlServer
    {
        public string ExecuteScalar(string cmdText, SqlConnection connection)
        {
            using (var command = new SqlCommand(cmdText, connection))
            {
                try
                {
                    command.Connection.Open();
                    return command.ExecuteScalar().ToString();

                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }

        public void ExecuteNonQuery(string cmdText, SqlConnection connection)
        {
            using (var command = new SqlCommand(cmdText, connection))
            {
                try
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();

                }
                finally
                {
                    command.Connection.Close();
                }
            }
        }
    }
}
