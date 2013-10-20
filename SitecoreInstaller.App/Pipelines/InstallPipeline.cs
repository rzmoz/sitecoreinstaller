using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  using Preconditions;
  using Steps;
  using Steps.Install;

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
      AddStep<TransformConfigFiles>();
      AddStep<AttachDatabases>();
      AddStep<AddSitenameToHostFile>();
      AddStep<CreateIisSiteAndAppPool>();
      AddStep<InstallRuntimeServices>();
      AddStep<InstallPackages>();
      AddStep<ConfigureFinishingTasks>();
      AddStep<DeserializeItems>();
      AddStep<RunPostInstallPowerShellScripts>();
      AddStep<WarmUpSite>();
    }
  }
}
