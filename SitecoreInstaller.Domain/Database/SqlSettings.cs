namespace SitecoreInstaller.Domain.Database
{
    using System;
    using System.Data.SqlClient;

    using SitecoreInstaller.Framework.Diagnostics;

    public class SqlSettings
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string InstanceName { get; set; }
        public bool UseIntegratedSecurity { get; set; }

        public string ConnectionString
        {
            get
            {
                if(UseIntegratedSecurity)
                    return string.Format(_ConnectionStringIntegratedSecurityFormat, InstanceName);
                return string.Format(_ConnectionStringFormat, InstanceName, Login, Password);
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

        private const string _ConnectionStringFormat = @"Data Source={0};Initial Catalog=Master;User Id={1};Password={2};";
        private const string _ConnectionStringIntegratedSecurityFormat = @"Data Source={0};Initial Catalog=Master;Integrated Security=SSPI;";
    }
}
