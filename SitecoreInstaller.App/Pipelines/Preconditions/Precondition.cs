using System;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  using SitecoreInstaller.Domain.Pipelines;
  using SitecoreInstaller.Framework.Linguistics;

  public abstract class Precondition<T> : IPrecondition where T : PipelineEventArgs
  {
    protected Precondition()
    {
      ErrorMessage = string.Empty;
      Name = new Sentence(this.GetType().Name);
    }

    public Sentence Name { get; private set; }

    public bool Evaluate(object sender, EventArgs args)
    {
      if (args is T == false)
        throw new ArgumentException("args must be of type:" + typeof(T) + ". Was:" + args.GetType());

      return this.InnerEvaluate(this, args as T);
    }
    public abstract bool InnerEvaluate(object sender, T args);

    public string ErrorMessage { get; set; }
  }
}
