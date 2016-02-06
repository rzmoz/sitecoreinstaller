using System;
using System.Threading.Tasks;
using CSharp.Basics.Diagnostics;
using CSharp.Basics.IO;
using CSharp.Basics.Pipelines;
using SitecoreInstaller.Kernel.Domain;

namespace SitecoreInstaller.Kernel.App.Install
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
            var sitecore = _buildLibrary.GetSitecore(args.ScBase);

            Task copyWebsiteFiles = Task.Factory.StartNew(() =>
            {
                //copy website files
                sitecore.SourceDir.ToDir("Website")
                    .CopyTo(args.TargetRootDir.ToDir("Website"), DirCopyOptions.IncludeSubDirectories);
                //copy data folder
                sitecore.SourceDir.ToDir("Databases")
                .CopyTo(args.TargetRootDir.ToDir("Databases"), DirCopyOptions.IncludeSubDirectories);
            });

            Task copyDatabaseFiles = Task.Factory.StartNew(() =>
            {
                sitecore.SourceDir.ToDir("Data")
                .CopyTo(args.TargetRootDir.ToDir(@"Website\App_Data"), DirCopyOptions.ExcludeSubDirectories);
            });

            Task copyCustomFiles = Task.Factory.StartNew(() =>
             {
                 sitecore.SourceDir.GetFiles().CopyTo(args.TargetRootDir, FileCopyOptions.OverwriteIfExists);
             });

            await Task.WhenAll(copyWebsiteFiles, copyDatabaseFiles, copyCustomFiles).ConfigureAwait(false);
        }
    }
}
