using System;
using System.Threading.Tasks;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App.Install
{
    public class CopySitecoreStep : TaskStep<InstallArgs>
    {
        private readonly IBuildLibrary _buildLibrary;

        public CopySitecoreStep(IBuildLibrary buildLibrary)
        {
            _buildLibrary = buildLibrary;
        }

        public override async Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            var sitecore = _buildLibrary.GetSitecore(args.SitecoreName);

            Task copyWebsiteFiles = Task.Factory.StartNew(() =>
            {
                //copy website files
                sitecore.ToDir("Website")
                    .CopyTo(args.WwwRoot, DirCopyOptions.IncludeSubDirectories);
                //copy data folder
                sitecore.ToDir("Databases")
                .CopyTo(args.InstallDir.ToDir("Databases"), DirCopyOptions.IncludeSubDirectories);
            });

            Task copyDatabaseFiles = Task.Factory.StartNew(() =>
            {
                sitecore.ToDir("Data")
                .CopyTo(args.WwwRoot.ToDir(@"App_Data"), DirCopyOptions.ExcludeSubDirectories);
            });

            Task copyCustomFiles = Task.Factory.StartNew(() =>
             {
                 sitecore.GetFiles().CopyTo(args.InstallDir, FileCopyOptions.OverwriteIfExists);
             });

            await Task.WhenAll(copyWebsiteFiles, copyDatabaseFiles, copyCustomFiles).ConfigureAwait(false);

            //ensure 64 bit assemblies are used
            var bin32BitFolder = args.WwwRoot.ToDir("bin");
            var bin64BitFolder = args.WwwRoot.ToDir("bin_x64");

            bin64BitFolder.CopyTo(bin32BitFolder, DirCopyOptions.ExcludeSubDirectories);
        }
    }
}
