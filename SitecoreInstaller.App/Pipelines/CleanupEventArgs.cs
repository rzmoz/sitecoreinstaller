using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines
{
  public class CleanupEventArgs : PipelineEventArgs
  {
    public CleanupEventArgs()
    {
      DeleteProject = false;
    }

    public bool DeleteProject { get; set; }
  }
}
