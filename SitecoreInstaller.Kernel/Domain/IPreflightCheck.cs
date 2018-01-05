using System.Threading.Tasks;
using DotNet.Standard.Tasks;

namespace SitecoreInstaller.Domain
{
    public interface IPreflightCheck
    {
        Task<TaskResult> AssertAsync();
    }
}
