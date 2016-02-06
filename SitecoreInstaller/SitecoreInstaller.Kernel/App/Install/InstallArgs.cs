using System;
using CSharp.Basics.IO;

namespace SitecoreInstaller.Kernel.App.Install
{
    public class InstallArgs : EventArgs
    {
        public IoDir TargetRootDir { get; set; }
        public string ScBase { get; set; }

        public UserPreferences UserPreferences { get; } = new UserPreferences();
    }
}