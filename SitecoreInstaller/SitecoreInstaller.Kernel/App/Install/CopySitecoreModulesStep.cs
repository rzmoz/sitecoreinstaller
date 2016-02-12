﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Basics.Diagnostics;
using CSharp.Basics.IO;
using CSharp.Basics.Pipelines;
using SitecoreInstaller.Kernel.Domain;
using SitecoreInstaller.Kernel.Domain.BuildLibrary;

namespace SitecoreInstaller.Kernel.App.Install
{
    public class CopySitecoreModulesStep : TaskStep<InstallArgs>
    {
        private readonly IBuildLibrary _buildLibrary;

        public CopySitecoreModulesStep(IBuildLibrary buildLibrary)
        {
            _buildLibrary = buildLibrary;
        }

        public override async Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            var modules = args.ModuleNames.Select(moduleName => _buildLibrary.GetModule(moduleName)).OfType<BuildLibraryFile>();

            Parallel.ForEach(modules, module =>
            {
                if (module.File.IsSitecorePackage())
                    module.File.CopyTo(args.WwwRoot.ToDir("App_Data", "packages"));
            });
        }
    }
}
