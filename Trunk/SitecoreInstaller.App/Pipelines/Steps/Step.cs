using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps
{
    using SitecoreInstaller.Domain.Pipelines;

    public abstract class Step : IStep
    {
        protected IList<IPrecondition> ProtectedPreconditions { get; private set; }
        public IEnumerable<IPrecondition> Preconditions { get { return ProtectedPreconditions; } }

        public event EventHandler<EventArgs> StepInvoking;
        public event EventHandler<EventArgs> StepInvoked;

        protected Step()
        {
            ProtectedPreconditions = new List<IPrecondition>();
        }

        public int Order { get; set; }

        public void Invoke(object sender, EventArgs args)
        {
            if (StepInvoking != null)
                StepInvoking(this, EventArgs.Empty);

            if (Preconditions.Any(precondition => precondition.Evaluate(sender, args) == false))
                return;

            InnerInvoke(sender, args);

            if (StepInvoked != null)
                StepInvoked(this, EventArgs.Empty);
        }

        protected abstract void InnerInvoke(object sender, EventArgs args);
    }
}
