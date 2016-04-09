﻿using System;
using System.Collections.Generic;
using DotNet.Basics.IO;

namespace SitecoreInstaller.App.Install
{
    public class InstallArgs : EventArgs
    {
        public IoDir InstallDir { get; set; }
        public IoDir WwwRoot { get; set; }
        public string SitecoreName { get; set; }
        public string LicenseName { get; set; }
        public string[] ModuleNames { get; set; }

        public UserPreferences UserPreferences { get; } = new UserPreferences();
    }
}