using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Basics.Diagnostics;
using CSharp.Basics.IO;
using CSharp.Basics.Pipelines;
using SitecoreInstaller.Kernel.Domain;

namespace SitecoreInstaller.Kernel.App.Install
{
    public class CopyModulesStep : TaskStep<InstallArgs>
    {
        private readonly IBuildLibrary _buildLibrary;

        public CopyModulesStep(IBuildLibrary buildLibrary)
        {
            _buildLibrary = buildLibrary;
        }

        public override async Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            var modules = args.ModuleNames.Select(moduleName => _buildLibrary.GetModule(moduleName));

            foreach (var module in modules.OfType<BuildLibraryDir>())
            {
                try
                {
                    //copy database files to database folder
                    var dbFiles = new[] { "*,mdf", "*.ldf" }
                        .SelectMany(fileExtensions => module.Dir.GetFiles(fileExtensions));

                    Parallel.ForEach(dbFiles, file =>
                    {
                        file.CopyTo(args.TargetRootDir.ToDir("Databases"), FileCopyOptions.OverwriteIfExists);
                    });
                }
                catch (IOException e)
                {
                    logger.Log(e.Message, LogLevel.Error, e);
                }
            }
        }
    }
}
