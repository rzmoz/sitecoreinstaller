using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Collections;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.Runtime.Install
{
    public class CopySitecoreModulesStep : PipelineStep<InstallArgs>
    {
        protected override async Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            //copy sitecore package files to 
            await args.Modules.Where(m => m.IsFolder == false).Cast<FilePath>().ParallelForEachAsync(async f =>
            {
                if (f == null)
                    return;
                if (f.IsSitecorePackage() == false)
                    return;
                f.CopyTo(args.WebsiteRoot.ToDir("App_Data", "packages"));
            }).ConfigureAwait(false);
        }
    }
}
