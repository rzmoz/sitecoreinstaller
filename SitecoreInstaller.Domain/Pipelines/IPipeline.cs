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
    EventArgs Args { get; set; }
  }
}
