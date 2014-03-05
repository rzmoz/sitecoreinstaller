using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Domain.Database;

namespace SitecoreInstaller.App.Pipelines.Steps.Azure
{
    public class CreateBacpacs : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            var msConnectionStrings = args.ProjectSettings.ProjectFolder.Website.AppConfig.ConnectionStringsConfigFile.Where(con => con.ConnectionString is MsSqlConnectionString).ToList();

            foreach (var connectionString in msConnectionStrings)
            {

            }
        }
    }
}
