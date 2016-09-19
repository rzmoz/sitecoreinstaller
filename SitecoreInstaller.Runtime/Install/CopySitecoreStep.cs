using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.Runtime.Install
{
    public class CopySitecoreStep : PipelineStep<InstallArgs>
    {
        protected override async Task InnerRunAsync(InstallArgs args, CancellationToken ct)
        {
            if (args.Sitecore.Exists() == false)
                throw new FileNotFoundException($"Sitecore not found:{args.Sitecore.FullName}");

            await Task.WhenAll(
                Task.Run(() =>
                {
                    //copy website files
                    args.Sitecore.ToDir("Website").CopyTo(args.WebsiteRoot, includeSubfolders: true);
                    //copy data folder
                    args.Sitecore.ToDir("Databases").CopyTo(args.InstallDir.ToDir("Databases"), includeSubfolders: false);
                }),
                Task.Run(() => { args.Sitecore.ToDir("Data").CopyTo(args.WebsiteRoot.ToDir("App_Data"), includeSubfolders: true); }),
                Task.Run(() => { args.Sitecore.ToDir().GetFiles().CopyTo(args.InstallDir, overwrite: true); })
            ).ConfigureAwait(false);

            //ensure 64 bit assemblies are used
            var bin32BitFolder = args.WebsiteRoot.ToDir("bin");
            var bin64BitFolder = args.WebsiteRoot.ToDir("bin_x64");

            bin64BitFolder.CopyTo(bin32BitFolder, includeSubfolders: false);
        }
    }
}
