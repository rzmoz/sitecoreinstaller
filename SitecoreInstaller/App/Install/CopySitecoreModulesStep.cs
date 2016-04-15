using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.IO;
using DotNet.Basics.Pipelines;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.BuildLibrary;


namespace SitecoreInstaller.App.Install
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
            var modules = _buildLibrary.GetModules(args.ModuleNames);

            var tasks = modules.Select(m => m.FileSystemInfo as FileInfo).Select(m =>
            {
                return Task.Factory.StartNew(() =>
                {
                    if (m == null)
                        return;
                    if (m.IsSitecorePackage() == false)
                        return;
                    m.CopyTo(args.WebsiteRoot.ToDir("App_Data", "packages"));
                });
            });
            await Task.WhenAll(tasks.ToArray()).ConfigureAwait(false);
        }
    }
}
