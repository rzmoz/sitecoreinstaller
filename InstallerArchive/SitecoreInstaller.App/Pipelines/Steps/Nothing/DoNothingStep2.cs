using System;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
    public class DoNothingStep2 : Step<DoNothingEventArgs>
    {
        protected override void InnerInvoke(object sender, DoNothingEventArgs args)
        {
        }
    }
}
