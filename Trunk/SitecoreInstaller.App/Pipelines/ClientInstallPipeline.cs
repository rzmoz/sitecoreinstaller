using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.App.Pipelines.Steps.Install;
    using SitecoreInstaller.Domain.Pipelines;

    public class ClientInstallPipeline : Pipeline
    {
        public ClientInstallPipeline()
        {
            //Init preconditions
            AddPrecondition<CheckProjectNameIsSet>();
            AddPrecondition<CheckSitecore>();
            AddPrecondition<CheckLicense>();
            AddPrecondition<CheckWritePermissionToHostFile>();

            //Init steps
            AddStep<CreateProjectFolder>();
            AddStep<UpdateAppSettings>();
            AddStep<CopySitecore>();
            AddStep<CopyLicensefile>();
            AddStep<SetDataFolder>();
            AddStep<CopyModuleFiles>();

            var addSitenameToHostFileWithNewPrecondition = new AddSitenameToHostFile();
            addSitenameToHostFileWithNewPrecondition .AddPrecondition<CheckConnectionstringsManuallyUpdated>();
            AddStep(addSitenameToHostFileWithNewPrecondition);
            
            AddStep<CreateIisSiteAndAppPool>();
            AddStep<InstallRuntimeServices>();
            AddStep<InstallPackages>();
            AddStep<ExecutePostInstallSteps>();
        }
    }
}
