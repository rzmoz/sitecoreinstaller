namespace SitecoreInstaller.PreflightChecks
{
    public interface IPreflightCheck
    {
        PreflightCheckResult Assert();
    }
}
