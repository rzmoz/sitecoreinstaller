using DotNet.Basics.Tasks;

namespace SitecoreInstaller
{
    public interface IPreflightCheck
    {
        TaskResult Assert();
    }
}
