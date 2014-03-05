using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Steps.Azure
{
    public class PrepDatabasesForBacpacFormat : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            var connectionStrings = args.ProjectSettings.ProjectFolder.Website.AppConfig.ConnectionStringsConfigFile;
                
        }
    }
}
