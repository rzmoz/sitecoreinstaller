using DotNet.Basics.Tasks;

namespace SitecoreInstaller.Domain
{
    public interface IPreflightCheck
    {
        TaskResult Assert();
    }
}
