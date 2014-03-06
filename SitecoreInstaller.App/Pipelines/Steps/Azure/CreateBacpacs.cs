using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Azure;
using SitecoreInstaller.Domain.Database;

namespace SitecoreInstaller.App.Pipelines.Steps.Azure
{
    public class CreateBacpacs : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            var entries =
                args.ProjectSettings.ProjectFolder.Website.AppConfig.ConnectionStringsConfigFile.Where(
                    con => con.ConnectionString is MsSqlConnectionString).ToList();
            foreach (var entry in entries)
            {
                var file = new FileInfo(args.ProjectSettings.ProjectName + "_" + entry.Name);

                AzureServices.Sql.CreateBacpac(file, entry);
                
            }
            /*
            Parallel.ForEach(entries, (entry) =>
            {
            });
            */
            throw new NotImplementedException();
        }
    }
}
