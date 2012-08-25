using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.App.Pipelines.Steps.Install;
    using SitecoreInstaller.Domain.Pipelines;

    public class ReAttachPipeline : SitecoreInstallerPipeline
    {
        public ReAttachPipeline(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
            //Init preconditions
            AddPrecondition(new CheckWritePermissionToHostFile(getAppSettings));

            //Init steps
            AddStep(new AttachDatabases(getAppSettings));
            AddStep(new AddSitenameToHostFile(getAppSettings));
            AddStep(new CreateIisSiteAndAppPool(getAppSettings));
        }
    }
}
