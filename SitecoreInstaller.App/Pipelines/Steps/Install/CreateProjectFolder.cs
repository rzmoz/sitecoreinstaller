using SitecoreInstaller.App.Pipelines.Preconditions;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class CreateProjectFolder : Step<PipelineEventArgs>
  {
    public CreateProjectFolder()
    {
      AddPrecondition<CheckProjectDoesNotExist>();
    }

    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      Services.Projects.CreateProject(args.ProjectSettings.ProjectFolder.Directory);
    }
  }
}
