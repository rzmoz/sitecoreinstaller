using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.Domain.Database;
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;

    public class TestSqlSettingsPipeline : IPipeline
    {
        private readonly SqlSettings _sqlSettings;

        private ILog _log;

        public TestSqlSettingsPipeline()
        {
            _log = new Log();
        }

        public void Init(ILog log)
        {
            _log = log ?? new Log();
        }

        public TestSqlSettingsPipeline(SqlSettings sqlSettings)
        {
            _sqlSettings = sqlSettings;
        }

        [Step(1)]
        public void TestDatabaseSettings(object sender, EventArgs e)
        {
            _log.Info("Testing Sql settings...");
            Services.Sql.TestDatabaseSettings(_sqlSettings);
        }
        [Step(2)]
        public void FinishingTest(object sender, EventArgs e)
        {
        }
    }
}
