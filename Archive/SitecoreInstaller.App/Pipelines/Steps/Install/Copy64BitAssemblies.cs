using System.IO;
using CSharp.Basics.IO;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class Copy64BitAssemblies : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            Services.WwwRoot.Copy64BitAssemblies(args.ProjectSettings.ProjectFolder.Website.Directory);
        }
    }
}
