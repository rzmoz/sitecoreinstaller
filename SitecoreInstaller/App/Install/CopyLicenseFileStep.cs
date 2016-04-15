using System.Threading.Tasks;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.App.Install
{
    public class CopyLicenseFileStep : TaskStep<InstallArgs>
    {
        public override async Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            await Task.Run(() =>
            {
                args.License.CopyTo(args.WebsiteRoot.ToDir("App_Data", "license.xml"));
            }).ConfigureAwait(false);
        }
    }
}
