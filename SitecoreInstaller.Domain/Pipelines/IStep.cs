using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
  using SitecoreInstaller.Framework.Linguistics;

  public interface IStep
  {
    Sentence Name { get; }

    event EventHandler<EventArgs> StepInvoking;
    event EventHandler<EventArgs> StepInvoked;

    int Order { get; set; }
    IEnumerable<IPrecondition> Preconditions { get; }
    void Invoke(object sender, EventArgs e);
  }
}
