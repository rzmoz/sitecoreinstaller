using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;
using SitecoreInstaller.Domain;


namespace SitecoreInstaller.App.Install
{
    public class CopySitecoreModulesStep : PipelineStep<InstallArgs>
    {
        public override async Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            //copy sitecore package files to 
            await Task.WhenAll(args.Modules.Select(m => m as FileInfo).Select(m =>
                {
                    return Task.Run(() =>
                    {
                        if (m == null)
                            return;
                        if (m.IsSitecorePackage() == false)
                            return;
                        m.CopyTo(args.WebsiteRoot.ToDir("App_Data", "packages"));
                    });
                })).ConfigureAwait(false);
        }
    }
}
