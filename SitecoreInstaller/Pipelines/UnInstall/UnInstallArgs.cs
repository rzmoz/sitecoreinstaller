using System;

namespace SitecoreInstaller.Pipelines.UnInstall
{
    public class UnInstallArgs : EventArgs
    {
        public string Name { get; set; }
        public bool WasDeleted { get; set; }
    }
}
