using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
  using SitecoreInstaller.Framework.Linguistics;

  public interface IPipeline
  {
    Sentence Name { get; }
    IEnumerable<IStep> Steps { get; }
    IEnumerable<IPrecondition> Preconditions { get; }
    Dialogs Dialogs { get; set; }
  }
}
