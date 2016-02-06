using System;
using System.Collections.Generic;
using SitecoreInstaller.Domain.Pipelines;
using SitecoreInstaller.Framework.Linguistics;

namespace SitecoreInstaller.App.Pipelines.Steps
{
    public abstract class Step<T> : IStep where T : PipelineApplicationEventArgs
    {
        private readonly IList<IPrecondition> _preconditions;
        public IEnumerable<IPrecondition> Preconditions { get { return _preconditions; } }

        public Sentence Name { get; private set; }
        public event EventHandler<EventArgs> StepInvoking;
        public event EventHandler<EventArgs> StepInvoked;

        protected Step()
        {
            _preconditions = new List<IPrecondition>();
            Name = new Sentence(this.GetType().Name);
        }

        public int Order { get; set; }

        public void AddPrecondition<TK>() where TK : IPrecondition, new()
        {
            _preconditions.Add(new TK());
        }

        public void Invoke(object sender, EventArgs args)
        {
            if (args is T == false)
                throw new ArgumentException("args must be of type:" + typeof(T) + ". Was:" + args.GetType());

            if (StepInvoking != null)
                StepInvoking(this, args);

            InnerInvoke(sender, args as T);

            if (StepInvoked != null)
                StepInvoked(this, args);
        }

        protected abstract void InnerInvoke(object sender, T args);
    }
}
