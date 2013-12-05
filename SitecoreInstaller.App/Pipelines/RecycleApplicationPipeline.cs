using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.App.Pipelines.MinorChecks;
using SitecoreInstaller.App.Pipelines.Preconditions;
using SitecoreInstaller.App.Pipelines.Steps;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class RecycleApplicationPipeline : Pipeline<PipelineApplicationEventArgs>
    {
        public RecycleApplicationPipeline()
        {
            //Init preconditions
            AddPrecondition<CheckProjectNameIsSet>();
            AddPrecondition<CheckProjectExists>();

            //Init steps
            AddStep<RecycleApplication>();
            AddStep<WarmUpSite>();
        }
    }
}
