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

        public TestSqlSettingsPipeline()
        {
        }

        public IEnumerable<IPrecondition> Preconditions
        {
            get { throw new NotImplementedException(); }
        }

        public void Init()
        {
        }

        public TestSqlSettingsPipeline(SqlSettings sqlSettings)
        {
            _sqlSettings = sqlSettings;
        }

        [Step(1)]
        public void TestDatabaseSettings(object sender, EventArgs e)
        {
            Log.It.Info("Testing Sql settings...");
            Services.Sql.TestDatabaseSettings(_sqlSettings);
        }
        [Step(2)]
        public void FinishingTest(object sender, EventArgs e)
        {
        }
    }
}
