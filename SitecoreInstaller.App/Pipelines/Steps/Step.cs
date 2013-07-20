using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps
{
  using SitecoreInstaller.Domain.Pipelines;
  using SitecoreInstaller.Framework.Linguistics;

  public abstract class Step : IStep
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

    public void AddPrecondition<T>() where T : IPrecondition, new()
    {
      _preconditions.Add(new T());
    }

    public void Invoke(object sender, EventArgs args)
    {
      if (args is PipelineEventArgs == false)
        throw new ArgumentException("args must be of type:" + typeof(PipelineEventArgs) + ". Was:" + args.GetType());

      if (StepInvoking != null)
        StepInvoking(this, args);

      InnerInvoke(sender, args as PipelineEventArgs);

      if (StepInvoked != null)
        StepInvoked(this, args);
    }

    protected abstract void InnerInvoke(object sender, PipelineEventArgs args);
  }
}
