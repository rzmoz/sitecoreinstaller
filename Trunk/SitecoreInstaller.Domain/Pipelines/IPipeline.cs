using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    public interface IPipeline
    {
        string Name { get; }
        IEnumerable<IStep> Steps { get; }
        IEnumerable<IPrecondition> Preconditions { get; }
        bool IsInUiMode { get; set; }
    }
}
