using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  using SitecoreInstaller.App.Pipelines.Preconditions;
  using SitecoreInstaller.App.Pipelines.Steps.Uninstall;

  public class UninstallPipeline : Pipeline<CleanupEventArgs>
  {
    public UninstallPipeline()
    {
      //Init preconditions
      AddPrecondition<CheckProjectNameIsSet>();
      AddPrecondition<CheckWritePermissionToHostFile>();
      AddPrecondition<CheckProjectExists>();
      AddPrecondition<CheckSqlConnection>();

      //Init steps
      AddStep<RunPreUninstallPowerShellScripts>();
      AddStep<StopApplication>();
      AddStep<DetachDatabases>();
      AddStep<DeleteIisSiteAndAppPool>();
      AddStep<DeleteSiteFromHostFile>();
      AddStep<RunPostUninstallPowerShellScripts>();
      AddStep<DeleteProject>();
    }
  }
}
