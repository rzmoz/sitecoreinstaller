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

        public string Name
        {
            get { return GetType().Name; }
        }

        public IEnumerable<IStep> Steps
        {
            get { return Enumerable.Empty<IStep>(); }
        }

        public IEnumerable<IPrecondition> Preconditions
        {
            get { return Enumerable.Empty<IPrecondition>(); }
        }

        public bool IsInUiMode { get; set; }

        public void Init()
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
