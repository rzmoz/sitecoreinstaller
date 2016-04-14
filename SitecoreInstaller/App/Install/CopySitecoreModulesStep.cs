using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;
using SitecoreInstaller.Domain;


namespace SitecoreInstaller.App.Install
{
    public class CopySitecoreModulesStep : TaskStep<InstallArgs>
    {
        
        public override async Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            /*
            var modules = args.ModuleNames.Select(moduleName => _buildLibrary.GetModule(moduleName)).OfType<BuildLibraryFile>();

            Parallel.ForEach(modules, module =>
            {
                if (module.File.IsSitecorePackage())
                    module.File.CopyTo(args.WwwRoot.ToDir("App_Data", "packages"));
            });
            */
        }
        
    }
}
