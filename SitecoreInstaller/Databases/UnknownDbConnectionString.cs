namespace SitecoreInstaller.Databases
{
    public class UnknownDbConnectionString : DbConnectionString
    {
        public UnknownDbConnectionString(string name, string value) : base(name, value, DbType.Unknown)
        {
        }
    }
}
