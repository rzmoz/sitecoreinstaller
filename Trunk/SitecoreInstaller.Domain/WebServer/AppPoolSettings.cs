using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.Administration;

namespace SitecoreInstaller.Domain.WebServer
{
    public class AppPoolSettings
    {
        public AppPoolSettings()
        {
            Name = string.Empty;
            ManagedRuntimeVersion = ClrVersion.V40;
            ManagedPipelineMode = ManagedPipelineMode.Integrated;
            Enable32BitAppOnWin64 = false;
            PingingEnabled = false;
            ProcessModelIdentityType = ProcessModelIdentityType.NetworkService;
        }


        public string Name { get; set; }
        public ClrVersion ManagedRuntimeVersion { get; set; }
        public ManagedPipelineMode ManagedPipelineMode { get; set; }
        public bool Enable32BitAppOnWin64 { get; set; }
        public bool PingingEnabled { get; set; }
        public ProcessModelIdentityType ProcessModelIdentityType { get; set; }
    }
}
