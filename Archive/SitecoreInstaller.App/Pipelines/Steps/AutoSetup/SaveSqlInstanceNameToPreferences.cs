using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps.AutoSetup
{
    public class SaveSqlInstanceNameToPreferences : Step<PipelineApplicationEventArgs>
{
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            var connection = Services.Sql.GetTrustedConnection();
            if (connection == null)
                return;

            args.ProjectSettings.Sql.InstanceName = connection.DataSource;
            Services.UserPreferences.Properties.SqlInstanceName = args.ProjectSettings.Sql.InstanceName;
            Services.UserPreferences.Save();
        }
}
}
