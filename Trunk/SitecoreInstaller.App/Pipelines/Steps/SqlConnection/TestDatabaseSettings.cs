using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.SqlConnection
{
    using SitecoreInstaller.Framework.Diagnostics;

    public class TestDatabaseSettings : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Log.It.Info("Testing Sql settings...");
            Services.Sql.TestDatabaseSettings(Services.AppSettings.Sql);
        }
    }
}
