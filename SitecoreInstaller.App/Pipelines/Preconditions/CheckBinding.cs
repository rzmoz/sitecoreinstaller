namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    public class CheckBinding : Precondition<PipelineApplicationEventArgs>
    {
        protected override bool InnerEvaluate(object sender, PipelineApplicationEventArgs args)
        {
            if (!Services.IisManagement.BindingExists(args.ProjectSettings.Iis.Url))
                return true;
            ErrorMessage = "Site with binding already exists: " + args.ProjectSettings.Iis.Url;
            return false;
        }
    }
}