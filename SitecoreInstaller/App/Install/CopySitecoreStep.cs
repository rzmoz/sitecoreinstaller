using System;
using System.IO;
using System.IO.Compression;
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
            if (sitecore == null)
                throw new FileNotFoundException($"Sitecore not found:{args.SitecoreName}");

            if (sitecore.IOType == IoType.File)
                ZipFile.ExtractToDirectory(sitecore.FullName, ((FileInfo)sitecore.FileSystemInfo).Directory.FullName);

            sitecore = _buildLibrary.GetSitecore(args.SitecoreName);//get resource as folder

            if (sitecore.IOType != IoType.Dir)
                throw new ApplicationException("Found sitecore is not directory");

            Task copyWebsiteFiles = Task.Factory.StartNew(() =>
            {
                //copy website files
                sitecore.FullName.ToDir("Website").CopyTo(args.WebsiteRoot, DirCopyOptions.IncludeSubDirectories);
                //copy data folder
                sitecore.FullName.ToDir("Databases").CopyTo(args.InstallDir.ToDir("Databases"), DirCopyOptions.ExcludeSubDirectories);
            });

            Task copyDatabaseFiles = Task.Factory.StartNew(() =>
            {
                sitecore.FullName.ToDir("Data").CopyTo(args.WebsiteRoot.ToDir("App_Data"), DirCopyOptions.IncludeSubDirectories);
            });

            Task copyCustomFiles = Task.Factory.StartNew(() =>
             {
                 sitecore.FullName.ToDir().GetFiles().CopyTo(args.InstallDir, overwrite: true);
             });

            await Task.WhenAll(copyWebsiteFiles, copyDatabaseFiles, copyCustomFiles).ConfigureAwait(false);

            //ensure 64 bit assemblies are used
            var bin32BitFolder = args.WebsiteRoot.ToDir("bin");
            var bin64BitFolder = args.WebsiteRoot.ToDir("bin_x64");

            bin64BitFolder.CopyTo(bin32BitFolder, DirCopyOptions.ExcludeSubDirectories);
        }
    }
}
