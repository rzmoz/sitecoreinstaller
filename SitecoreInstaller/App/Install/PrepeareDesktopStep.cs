using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Basics.Pipelines;
using Microsoft.Extensions.Logging;

namespace SitecoreInstaller.App.Install
{
    public class PrepeareDesktopStep : PipelineStep<InstallArgs>
    {
        public override Task RunAsync(InstallArgs args, ILogger logger)
        {
            throw new NotImplementedException();
        }
    }
}
