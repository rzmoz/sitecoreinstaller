using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
  public class ArchiveEventArgs : PipelineEventArgs
  {
    public string ArchiveName { get; set; }
  }
}
