using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps.Databases
{
    public class TryStartSqlServer : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            if (Services.Sql.IsStarted())
                return;

            Services.Sql.TryStartDefaultSqlService();
        }
    }
}
