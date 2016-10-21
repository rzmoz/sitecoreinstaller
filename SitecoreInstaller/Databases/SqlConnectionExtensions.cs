using System.Data.SqlClient;

namespace SitecoreInstaller.Databases
{
    public static class SqlConnectionExtensions
    {
        public static string ExecuteScalar(this SqlConnection connection, string cmdText)
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

        public static void ExecuteNonQuery(this SqlConnection connection, string cmdText)
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
