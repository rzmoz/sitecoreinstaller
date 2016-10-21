using System;
using System.Data.SqlClient;
using NLog;

namespace SitecoreInstaller.Databases
{
    public class SqlSettings
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string InstanceName { get; set; }

        public SqlConnectionString ConnectionString => new SqlConnectionString(this, new ConnectionStringName("master"));

        public void SetToInitialSettings()
        {
            InstanceName = ".";
            Login = "sc";
            Password = "1234";
        }

        public bool TestConnection()
        {
            try
            {
                var connectionString = ConnectionString + ";Connect Timeout=5";
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("SELECT COUNT(*) FROM sys.all_views", sqlConnection);
                    try
                    {
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                LogManager.GetCurrentClassLogger().Error(e);
                return false;
            }
        }
    }
}
