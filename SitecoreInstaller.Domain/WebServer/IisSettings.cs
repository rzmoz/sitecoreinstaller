using Microsoft.Web.Administration;

namespace SitecoreInstaller.Domain.WebServer
{
    public class IisSettings
    {
        public IisSettings()
        {
            Name = string.Empty;
            Url = string.Empty;
            ManagedRuntimeVersion = ClrVersion.V40;
            ManagedPipelineMode = ManagedPipelineMode.Integrated;
            Enable32BitAppOnWin64 = false;
            PingingEnabled = false;
            ProcessModelIdentityType = ProcessModelIdentityType.NetworkService;
        }
        public string Name { get; set; }
        public string Url { get; set; }
        public ClrVersion ManagedRuntimeVersion { get; set; }
        public ManagedPipelineMode ManagedPipelineMode { get; set; }
        public bool Enable32BitAppOnWin64 { get; set; }
        public bool PingingEnabled { get; set; }
        public ProcessModelIdentityType ProcessModelIdentityType { get; set; }
    }
}
