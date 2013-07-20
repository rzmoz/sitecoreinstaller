using System;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  using SitecoreInstaller.Domain.Pipelines;
  using SitecoreInstaller.Framework.Linguistics;

  public abstract class Precondition : IPrecondition
  {
    protected Precondition()
    {
      ErrorMessage = string.Empty;
      Name = new Sentence(this.GetType().Name);
    }

    public Sentence Name { get; private set; }

    public bool Evaluate(object sender, EventArgs args)
    {
      if (args is PipelineEventArgs == false)
        throw new ArgumentException("args must be of type:" + typeof(PipelineEventArgs) + ". Was:" + args.GetType());

      return this.InnerEvaluate(this, args as PipelineEventArgs);
    }
    public abstract bool InnerEvaluate(object sender, PipelineEventArgs args);

    public string ErrorMessage { get; set; }
  }
}
