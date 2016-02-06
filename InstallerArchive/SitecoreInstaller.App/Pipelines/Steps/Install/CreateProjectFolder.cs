using SitecoreInstaller.App.Pipelines.Preconditions;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class CreateProjectFolder : Step<PipelineApplicationEventArgs>
    {
        public CreateProjectFolder()
        {
            AddPrecondition<CheckProjectDoesNotExist>();
        }

        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            Services.Projects.CreateProject(args.ProjectSettings.ProjectFolder.Directory);
        }
    }
}
