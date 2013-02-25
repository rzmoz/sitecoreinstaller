using System;
using System.Linq;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Domain.Database;
using SitecoreInstaller.Domain.Pipelines;
using SitecoreInstaller.Framework.Xml;

namespace SitecoreInstaller.App.Pipelines
{
  using SitecoreInstaller.App.Pipelines.Preconditions;
  using SitecoreInstaller.App.Pipelines.Steps.Install;

  public class InstallPipeline : Pipeline
  {
    public InstallPipeline()
    {
      //Init preconditions
      AddPrecondition<CheckProjectNameIsSet>();
      AddPrecondition<CheckProjectDoesNotExist>();
      AddPrecondition<CheckSitecore>();
      AddPrecondition<CheckBinding>();
      AddPrecondition<CheckSqlConnection>();
      AddPrecondition<CheckLicense>();
      AddPrecondition<CheckWritePermissionToHostFile>();

      //Init steps
      AddStep<CreateProjectFolder>();
      AddStep<GrantPermissions>();
      AddStep<UpdateProjectSettings>();
      AddStep<CopySitecore>();
      AddStep<CopyLicensefile>();
      AddStep<SetDataFolder>();
      AddStep<CopyModuleFiles>();
      AddStep<SetConnectionStrings>();
      AddStep<AttachDatabases>();
      AddStep<AddSitenameToHostFile>();
      AddStep<CreateIisSiteAndAppPool>();
      AddStep<InstallRuntimeServices>();
      AddStep<InstallPackages>();
      AddStep<ExecutePostInstallSteps>();
    }
  }
}
