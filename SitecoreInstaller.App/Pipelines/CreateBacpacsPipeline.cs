using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.App.Pipelines.Preconditions;
using SitecoreInstaller.App.Pipelines.Steps.Azure;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class CreateBacpacsPipeline : Pipeline<PipelineApplicationEventArgs>
    {
        public CreateBacpacsPipeline()
        {
            //Init preconditions
            AddPrecondition<CheckProjectNameIsSet>();
            AddPrecondition<CheckProjectExists>();
            AddPrecondition<CheckSqlConnection>();

            //Init steps
            AddStep<PrepDatabases>();
            AddStep<CreateBacpacs>();
        }
    }
}
