using System.IO;
using Microsoft.Web.Administration;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class GrantPermissions : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      args.ProjectSettings.ProjectFolder.GrantFullControl("everyone");
      new DirectoryInfo(@"c:\windows\temp").GrantFullControl(ProcessModelIdentityType.NetworkService.ToString());
    }
  }
}
