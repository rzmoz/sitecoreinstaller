using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App.Install
{
    public class CopySitecoreInstallerModulesStep : TaskStep<InstallArgs>
    {
        private readonly IBuildLibrary _buildLibrary;

        public CopySitecoreInstallerModulesStep(IBuildLibrary buildLibrary)
        {
            _buildLibrary = buildLibrary;
        }

        public override async Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            var modules = _buildLibrary.GetModules(args.ModuleNames);

            foreach (var module in modules.Select(m => m.FileSystemInfo as DirectoryInfo))
            {
                if (module == null)
                    continue;

                //copy database files to database folder
                var dbFiles = new[] { RegisteredFileTypes.SqlMdf.GetAllSearchPattern, RegisteredFileTypes.SqlLdf.GetAllSearchPattern }
                    .SelectMany(fileExtensions => module.GetFiles(fileExtensions));
                dbFiles.CopyTo(args.InstallDir.ToDir("Databases"), overwrite: true);

                //copy powershell files
                module.GetFiles(RegisteredFileTypes.PowerShellScript.Extension).CopyTo(args.InstallDir);

                //copy config delta files to project root folder
                //we don't copy delta files to project since we read them directly from the source modules to avoid naming conflicts

                //copy config files to App_Config/Include folder
                module.GetFiles(RegisteredFileTypes.SitecoreConfig.Extension).CopyTo(args.WebsiteRoot.ToDir("App_Config", "Include"), overwrite: true);

                //copy disabled config files to App_Config/Include folder
                module.GetFiles(RegisteredFileTypes.DisabledSitecoreConfig.Extension).CopyTo(args.WebsiteRoot.ToDir("App_Config", "Include"), overwrite: true);

                //copy Sitecore packages to package folder (zip files)
                module.GetFiles(RegisteredFileTypes.SitecorePackage.Extension).CopyTo(args.WebsiteRoot.ToDir("App_Data", "packages"), overwrite: true);

                //copy Sitecore update packages to package folder (update files)
                module.GetFiles(RegisteredFileTypes.SitecoreUpdate.Extension).CopyTo(args.WebsiteRoot.ToDir("App_Data", "packages"), overwrite: true);

                //Copy rest of files as is
                Array.FindAll(module.GetFiles().ToArray(), RegisteredFileTypes.IsNotRegisteredFileType).CopyTo(args.InstallDir, overwrite: true);

                //Copy directories to project folder
                module.GetDirectories().CopyTo(args.InstallDir);
            }
        }
    }
}
