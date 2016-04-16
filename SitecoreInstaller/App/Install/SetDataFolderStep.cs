using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.App.Install
{
    public class SetDataFolderStep : PipelineStep<InstallArgs>
    {
        public override async Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            throw new NotImplementedException();
        }
    }
}
