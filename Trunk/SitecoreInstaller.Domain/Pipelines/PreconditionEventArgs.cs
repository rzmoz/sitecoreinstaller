using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    public class PreconditionEventArgs : EventArgs
    {
        public bool KillDialogs { get; set; }
    }
}
