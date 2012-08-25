using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    public class PreconditionEventArgs : EventArgs
    {
        public PreconditionEventArgs(AppSettings appSettings)
        {
            AppSettings = appSettings;
        }

        public AppSettings AppSettings { get; private set; }
    }
}
