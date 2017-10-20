using System;
using Microsoft.Web.Administration;

namespace SitecoreInstaller.WebServer
{
    public class AppPoolSettings
    {
        public AppPoolSettings(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            Name = name;
            ManagedRuntimeVersion = "v4.0";
            ManagedPipelineMode = ManagedPipelineMode.Integrated;
            Enable32BitAppOnWin64 = false;
            PingEnabled = false;
            ProcessModelIdentityType = ProcessModelIdentityType.NetworkService;
        }

        public string Name { get; }
        public string ManagedRuntimeVersion { get; set; }
        public ManagedPipelineMode ManagedPipelineMode { get; set; }
        public bool Enable32BitAppOnWin64 { get; set; }
        public bool PingEnabled { get; set; }
        public ProcessModelIdentityType ProcessModelIdentityType { get; set; }
    }
}
