namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckBinding : Precondition
    {
        public override bool InnerEvaluate(object sender, StepEventArgs args)
        {
            if (!Services.IisManagement.BindingExists(args.ProjectSettings.Iis.Url))
                return true;

            ErrorMessage = "Site with binding already exists: " + args.ProjectSettings.Iis.Url;
            return false;
        }
    }
}
