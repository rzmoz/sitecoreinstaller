using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps.AutoSetup
{
    public class DetermineSqlConnection : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            if (Services.Sql.IsStarted())
                return;

            var connection = Services.Sql.DetermineSqlConnection();
            args.ProjectSettings.Sql.InstanceName = connection.DataSource;
            Services.UserPreferences.Properties.SqlInstanceName = args.ProjectSettings.Sql.InstanceName;
            Services.UserPreferences.Save();
        }
    }
}
