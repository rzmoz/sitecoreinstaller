using System;
using SitecoreInstaller.Domain.Pipelines;
using SitecoreInstaller.Framework.Linguistics;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public abstract class Precondition<T> : IPrecondition where T : PipelineApplicationEventArgs
  {
    protected Precondition()
    {
      ErrorMessage = string.Empty;
      Name = new Sentence(GetType().Name);
    }

    public Sentence Name { get; private set; }

    public bool Evaluate(object sender, EventArgs args)
    {
      if (args is T == false)
        throw new ArgumentException("args must be of type:" + typeof(T) + ". Was:" + args.GetType());

      return InnerEvaluate(this, args as T);
    }
    public abstract bool InnerEvaluate(object sender, T args);

    public string ErrorMessage { get; set; }
  }
}
