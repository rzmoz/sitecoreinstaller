namespace SitecoreInstaller.Databases
{
    public interface IConnectionString
    {
        string Value { get; set; }
        bool IsValid();
    }
}
