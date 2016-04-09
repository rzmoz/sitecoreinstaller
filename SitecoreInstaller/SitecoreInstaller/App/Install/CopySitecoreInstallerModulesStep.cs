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
            var modules = args.ModuleNames.Select(moduleName => _buildLibrary.GetModule(moduleName));

            foreach (var module in modules.OfType<BuildLibraryDir>())
            {
                //copy database files to database folder
                var dbFiles = new[] { RegisteredFileTypes.SqlMdf.GetAllSearchPattern, RegisteredFileTypes.SqlLdf.GetAllSearchPattern }
                    .SelectMany(fileExtensions => module.Dir.GetFiles(fileExtensions));
                dbFiles.CopyTo(args.TargetRootDir.ToDir("Databases"), FileCopyOptions.OverwriteIfExists);

                //copy powershell files
                module.Dir.GetFiles(RegisteredFileTypes.PowerShellScript.Extension).CopyTo(args.TargetRootDir);

                //copy config delta files to project root folder
                //we don't copy delta files to project since we read them directly from the source modules to avoid naming conflicts

                //copy config files to App_Config/Include folder
                module.Dir.GetFiles(RegisteredFileTypes.SitecoreConfig.Extension).CopyTo(args.WwwRoot.ToDir("App_Config", "Include"), FileCopyOptions.OverwriteIfExists);

                //copy disabled config files to App_Config/Include folder
                module.Dir.GetFiles(RegisteredFileTypes.DisabledSitecoreConfig.Extension).CopyTo(args.WwwRoot.ToDir("App_Config", "Include"), FileCopyOptions.OverwriteIfExists);

                //copy Sitecore packages to package folder (zip files)
                module.Dir.GetFiles(RegisteredFileTypes.SitecorePackage.Extension).CopyTo(args.WwwRoot.ToDir("App_Data", "packages"), FileCopyOptions.OverwriteIfExists);

                //copy Sitecore update packages to package folder (update files)
                module.Dir.GetFiles(RegisteredFileTypes.SitecoreUpdate.Extension).CopyTo(args.WwwRoot.ToDir("App_Data", "packages"), FileCopyOptions.OverwriteIfExists);

                //Copy rest of files
                Array.FindAll(module.Dir.GetFiles().ToArray(), RegisteredFileTypes.IsNotRegisteredFileType).CopyTo(args.TargetRootDir, FileCopyOptions.OverwriteIfExists);

                //Copy directories to project folder
                module.Dir.GetDirectories().CopyTo(args.TargetRootDir);
            }

            
        }
    }
}
