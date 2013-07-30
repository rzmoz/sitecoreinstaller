using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  using SitecoreInstaller.App.Pipelines.Preconditions;
  using SitecoreInstaller.App.Pipelines.Steps;
  using SitecoreInstaller.App.Pipelines.Steps.Install;

  public class InstallPipeline : Pipeline<PipelineEventArgs>
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
      AddStep<SaveProjectSettings>();
      AddStep<RunPreInstallPowerShellScripts>();
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
      AddStep<DeserializeItems>();
      AddStep<RunSitecorePostInstallSteps>();
      AddStep<RunPostInstallPowerShellScripts>();
      AddStep<WarmUpNoWait>();
    }
  }
}
