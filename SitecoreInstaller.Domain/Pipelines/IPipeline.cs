using System;
using System.Collections.Generic;

namespace SitecoreInstaller.Domain.Pipelines
{
  using SitecoreInstaller.Framework.Linguistics;

  public interface IPipeline
  {
    Sentence Name { get; }
    IEnumerable<IPrecondition> Preconditions { get; }
    IEnumerable<IStep> Steps { get; }
    EventArgs Args { get; set; }
  }
}
