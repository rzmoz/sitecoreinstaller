using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.App.Pipelines.Preconditions;
using SitecoreInstaller.App.Pipelines.Steps;
using SitecoreInstaller.App.Pipelines.Steps.Install;
using SitecoreInstaller.App.Pipelines.Steps.Maintenance;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class UpdateLicenseFilePipeline : Pipeline<PipelineApplicationEventArgs>
    {
        public UpdateLicenseFilePipeline()
        {
            AddPrecondition<CheckProjectNameIsSet>();
            AddPrecondition<CheckProjectExists>();
            AddPrecondition<CheckLicense>();

            AddStep<SaveProjectSettings>();
            AddStep<CopyLicenseFile>();
            AddStep<RecycleApplication>();
            AddStep<WarmUpSite>();
        }
    }
}
