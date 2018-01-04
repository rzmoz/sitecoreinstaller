using System.Threading.Tasks;
using DotNet.Basics.Tasks;

namespace SitecoreInstaller.Domain
{
    public interface IPreflightCheck
    {
        Task<TaskResult> AssertAsync();
    }
}
