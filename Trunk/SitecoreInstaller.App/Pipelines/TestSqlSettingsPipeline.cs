using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.Domain.Database;
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;

    public class TestSqlSettingsPipeline : Pipeline
    {
        private readonly SqlSettings _sqlSettings;

        public TestSqlSettingsPipeline()
        {
        }

        public TestSqlSettingsPipeline(SqlSettings sqlSettings)
        {
            _sqlSettings = sqlSettings;
        }

        public void TestDatabaseSettings(object sender, EventArgs e)
        {
            Log.It.Info("Testing Sql settings...");
            Services.Sql.TestDatabaseSettings(_sqlSettings);
        }
        
        public void FinishingTest(object sender, EventArgs e)
        {
        }
    }
}
