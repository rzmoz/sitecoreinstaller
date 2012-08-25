using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.App.Pipelines.Steps.SqlConnection;
    using SitecoreInstaller.Domain.Database;
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;

    public class TestSqlSettingsPipeline : SitecoreInstallerPipeline
    {
        public TestSqlSettingsPipeline(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
            //Init steps
            AddStep(new TestDatabaseSettings(getAppSettings));
        }
    }
}
