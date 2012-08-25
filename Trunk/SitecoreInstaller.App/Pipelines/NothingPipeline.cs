using System;
using System.Threading;

using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.App.Pipelines.Steps.Nothing;

    public class NothingPipeline : Pipeline
    {
        public NothingPipeline()
        {
            AddStep(new DoNothing());
            //AddStep(new DoNothingForAWhile());
        }
    }
}
