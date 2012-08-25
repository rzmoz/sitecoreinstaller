using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    public interface IStep
    {
        event EventHandler<EventArgs> StepInvoking;
        event EventHandler<EventArgs> StepInvoked;

        int Order { get; }
        IEnumerable<IPrecondition> Preconditions { get; }
        void Invoke(object sender, EventArgs e);
    }
}
