using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  using SitecoreInstaller.Domain.Pipelines;
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.Linguistics;
  using SitecoreInstaller.Framework.System;

  public abstract class Precondition : IPrecondition
  {
    protected Precondition()
    {
      ErrorMessage = string.Empty;
      Name = new Sentence(this.GetType().Name);
    }

    public Sentence Name { get; private set; }
    public abstract bool Evaluate(object sender, PreconditionEventArgs args);

    public string ErrorMessage { get; set; }
  }
}
