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
        public PipelineRunner<TestSqlSettingsPipeline> GetSqlSettingsTest(SqlSettings sqlSettings)
        {
            return GetPipelineRunner(new TestSqlSettingsPipeline(sqlSettings));
        }

        public PipelineRunner<InstallPipeline> GetInstaller(Func<AppSettings> getAppSettings)
        {
            return GetPipelineRunner(new InstallPipeline(getAppSettings));
        }

        public PipelineRunner<UninstallPipeline> GetUnInstaller(Func<AppSettings> getAppSettings)
        {
            return GetPipelineRunner(new UninstallPipeline(getAppSettings));
        }

        public PipelineRunner<ReAttachPipeline> GetReAttach(Func<AppSettings> getAppSettings)
        {
            return GetPipelineRunner(new ReAttachPipeline(getAppSettings));
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
