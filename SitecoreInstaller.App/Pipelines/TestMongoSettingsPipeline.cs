using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.App.Pipelines.Steps.Databases;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class TestMongoSettingsPipeline : Pipeline<PipelineApplicationEventArgs>
    {
        public TestMongoSettingsPipeline()
        {
            AddStep<VerifyMongoDbConnection>();
        }
    }
}
