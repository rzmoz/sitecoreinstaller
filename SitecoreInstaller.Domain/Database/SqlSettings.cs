using System;
using System.Data.SqlClient;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Domain.Database
{
    public class SqlSettings
    {
        public DbInstallType InstallType { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string InstanceName { get; set; }

        public MsSqlConnectionString ConnectionString
        {
            get
            {
                return new MsSqlConnectionString(this, new ConnectionStringName("master"));
            }
        }

        public void SetToInitialSettings()
        {
            InstanceName = ".";
            Login = "sc";
            Password = "1234";
            InstallType = DbInstallType.Local;
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
                Log.ToApp.Debug(e.ToString());
                Log.ToApp.Error(e.Message);
                return false;
            }
        }
    }
}
