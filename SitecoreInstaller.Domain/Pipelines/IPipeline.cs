using System.Collections.Generic;
using SitecoreInstaller.Framework.Linguistics;

namespace SitecoreInstaller.Domain.Pipelines
{
  public interface IPipeline
  {
    Sentence Name { get; }
    IEnumerable<IPrecondition> Preconditions { get; }
    IEnumerable<IStep> Steps { get; }
    PipelineEventArgs Args { get; set; }
  }
}
