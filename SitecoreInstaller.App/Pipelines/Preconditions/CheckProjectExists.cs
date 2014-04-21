using System.IO;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    public class CheckProjectExists : Precondition<PipelineApplicationEventArgs>
    {
        protected override bool InnerEvaluate(object sender, PipelineApplicationEventArgs args)
        {
            if (Directory.Exists(args.ProjectSettings.ProjectFolder.FullName))
                return true;

            ErrorMessage = string.Format("Project '{0}' doesn't exist.\r\n\r\nLocation: {1}", args.ProjectSettings.ProjectName, args.ProjectSettings.ProjectFolder);
            return false;
        }
    }
}