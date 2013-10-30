using System.IO;
using Microsoft.Web.Administration;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class GrantPermissions : Step<PipelineApplicationEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
    {
      args.ProjectSettings.ProjectFolder.GrantFullControl("everyone");
      new DirectoryInfo(@"c:\windows\temp").GrantFullControl(ProcessModelIdentityType.NetworkService.ToString());
    }
  }
}
