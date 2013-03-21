﻿using System;
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
      if (StepInvoking != null)
        StepInvoking(this, EventArgs.Empty);

      InnerInvoke(sender, new StepEventArgs()); ;

      if (StepInvoked != null)
        StepInvoked(this, EventArgs.Empty);
    }

    protected abstract void InnerInvoke(object sender, StepEventArgs args);
  }
}
