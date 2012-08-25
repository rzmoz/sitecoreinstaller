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
        }

        protected override void InitPreconditions()
        {
            AddPrecondition(new CheckWritePermissionToHostFile(AppSettings));
        }

        protected override void InitSteps()
        {
            AddStep(new AttachDatabases(AppSettings));
            AddStep(new AddSitenameToHostFile(AppSettings));
            AddStep(new CreateIisSiteAndAppPool(AppSettings));
        }
    }
}
