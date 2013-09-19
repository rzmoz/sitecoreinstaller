namespace SitecoreInstaller.Domain.Database
{
    using System;
    using System.Data.SqlClient;

    using Framework.Diagnostics;

    public class SqlSettings
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string InstanceName { get; set; }
        public bool UseIntegratedSecurity { get; set; }

        public MsSqlConnectionString ConnectionString
        {
            get
            {
                return new MsSqlConnectionString(this, new ConnectionStringName("master"));
            }
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
                Log.This.Debug(e.ToString());
                Log.This.Error(e.Message);
                return false;
            }
        }



    }
}
