using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;
using Microsoft.Extensions.Logging;

namespace SitecoreInstaller.App.Install
{
    public class CopyLicenseFileStep : PipelineStep<InstallArgs>
    {
        public override async Task RunAsync(InstallArgs args, ILogger logger)
        {
            await Task.Run(() =>
            {
                args.License.CopyTo(args.WebsiteRoot.ToDir("App_Data", "license.xml"));
            }).ConfigureAwait(false);
        }
    }
}
