using System;
using System.Collections.Generic;
using System.Linq;

namespace SitecoreInstaller.Domain.Pipelines
{
    public class Step
    {
        protected Action<object, EventArgs> Action { get; set; }

        public event EventHandler<EventArgs> StepInvoking;
        public event EventHandler<EventArgs> StepInvoked;

        public Step(string text, int order, Action<object, EventArgs> action)
        {
            Text = text;
            Order = order;
            Action = action;
            //we default to always run
            Preconditions = new List<Func<string, bool>> { DefaultPrecondition };
        }
        private static bool DefaultPrecondition(string @null)
        {
            return true;
        }

        public string Text { get; private set; }
        public int Order { get; private set; }

        public virtual string ActionName { get { return Action.Method.Name; } }
        public IEnumerable<Func<string, bool>> Preconditions { get; set; }

        public void Invoke(object sender, EventArgs e)
        {
            if (StepInvoking != null)
                StepInvoking(this, EventArgs.Empty);

            if (Preconditions.Any(func => func(ActionName) == false))
                return;

            Action.Invoke(sender, e);

            if (StepInvoked != null)
                StepInvoked(this, EventArgs.Empty);
        }
    }
}
