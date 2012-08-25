using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.Domain.Database;
    using SitecoreInstaller.Framework.Diagnostics;

    public class PipelineManager
    {
        public PipelineRunner<TestSqlSettingsPipeline> GetSqlSettingsTest()
        {
            return GetPipelineRunner(new TestSqlSettingsPipeline());
        }

        public PipelineRunner<InstallPipeline> GetInstaller()
        {
            return GetPipelineRunner(new InstallPipeline());
        }

        public PipelineRunner<UninstallPipeline> GetUnInstaller()
        {
            return GetPipelineRunner(new UninstallPipeline());
        }

        public PipelineRunner<ReAttachPipeline> GetReAttach()
        {
            return GetPipelineRunner(new ReAttachPipeline());
        }

        public PipelineRunner<NothingPipeline> GetNoting()
        {
            return GetPipelineRunner(new NothingPipeline());
        }

        private PipelineRunner<T> GetPipelineRunner<T>(T pipeline) where T : class,IPipeline
        {
            return new PipelineRunner<T>(pipeline);
        }
    }
}
