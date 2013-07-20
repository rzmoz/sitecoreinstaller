using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
  public class DoNothingEventArgs : PipelineEventArgs
  {
    public DoNothingEventArgs()
    {
      Wait = 1000;
    }

    public int Wait { get; set; }
  }
}
