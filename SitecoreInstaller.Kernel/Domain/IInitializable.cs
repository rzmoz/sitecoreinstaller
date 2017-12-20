using System.Threading.Tasks;
using DotNet.Basics.Tasks;

namespace SitecoreInstaller.Domain
{
    public interface IInitializable
    {
        Task<TaskResult> InitAsync();
    }
}
