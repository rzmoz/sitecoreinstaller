using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class DeserializeItems : Step
  {
    protected override void InnerInvoke(object sender, StepEventArgs args)
    {
      Services.Website.DeserializeItems(args.ProjectSettings.Iis.Url);
    }
  }
}
