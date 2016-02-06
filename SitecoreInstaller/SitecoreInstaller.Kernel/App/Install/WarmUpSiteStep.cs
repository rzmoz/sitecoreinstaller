using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Basics.Diagnostics;
using CSharp.Basics.Pipelines;

namespace SitecoreInstaller.Kernel.App.Install
{
    public class WarmUpSiteStep : TaskStep<InstallArgs>
    {
        public override Task RunAsync(InstallArgs args, IDiagnostics logger)
        {
            throw new NotImplementedException();
        }
    }
}
