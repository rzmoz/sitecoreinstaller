using System;
using System.Collections.Generic;
using SitecoreInstaller.Framework.Linguistics;

namespace SitecoreInstaller.Domain.Pipelines
{
    public interface IStep
    {
        Sentence Name { get; }

        event EventHandler<EventArgs> StepInvoking;
        event EventHandler<EventArgs> StepInvoked;

        int Order { get; set; }
        IEnumerable<IPrecondition> Preconditions { get; }
        void Invoke(object sender, EventArgs e);
    }
}
