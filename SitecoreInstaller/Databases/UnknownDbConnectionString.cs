namespace SitecoreInstaller.Databases
{
    public class UnknownDbConnectionString : DbConnectionString
    {
        public UnknownDbConnectionString(string name, string value) : base(name, string.Empty, value, DbType.Unknown)
        {
        }
    }
}
