namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    public class CheckProjectNameIsSet : Precondition<PipelineApplicationEventArgs>
    {
        protected override bool InnerEvaluate(object sender, PipelineApplicationEventArgs args)
        {
            if (args.ProjectSettings.ProjectNameIsSet)
                return true;
            ErrorMessage = "Project name not set. Please enter project name";
            return false;
        }
    }
}