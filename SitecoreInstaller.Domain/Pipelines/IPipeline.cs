using System;
using System.Collections.Generic;

namespace SitecoreInstaller.Domain.Pipelines
{
  using SitecoreInstaller.Framework.Linguistics;

  public interface IPipeline
  {
    Sentence Name { get; }
    IEnumerable<IStep> Steps { get; }
    IEnumerable<IPrecondition> Preconditions { get; }
    Dialogs Dialogs { get; set; }
    EventArgs Args { get; set; }
  }
}
