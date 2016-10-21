namespace SitecoreInstaller.Databases
{
    public class SqlConnectionString : BaseConnectionString
    {
        private const string _connectionStringFormat = "user id={0};password={1};Data Source={2};Database={3}";

        public SqlConnectionString() { }

        public SqlConnectionString(SqlSettings parameters, ConnectionStringName connectionStringName)
        {
            Value = string.Format(_connectionStringFormat, parameters.Login, parameters.Password, parameters.InstanceName, connectionStringName);
        }
    }
}
