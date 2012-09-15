using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    public class StepEventArgs : EventArgs
    {
        public StepEventArgs()
        {
            PreconditionEventArgs = new PreconditionEventArgs();
        }

        public PreconditionEventArgs PreconditionEventArgs { get; private set; }
    }
}
