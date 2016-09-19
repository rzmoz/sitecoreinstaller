using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.Runtime.Install
{
    public class CopyLicenseFileStep : PipelineStep<InstallArgs>
    {
        protected override async Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            args.License.CopyTo(args.WebsiteRoot.ToDir("App_Data", "license.xml"));
        }
    }
}
