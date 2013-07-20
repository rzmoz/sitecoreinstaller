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
      if (args is StepEventArgs == false)
        throw new ArgumentException("args must be of type:" + typeof(StepEventArgs) + ". Was:" + args.GetType());

      return this.InnerEvaluate(this, args as StepEventArgs);
    }
    public abstract bool InnerEvaluate(object sender, StepEventArgs args);

    public string ErrorMessage { get; set; }
  }
}
