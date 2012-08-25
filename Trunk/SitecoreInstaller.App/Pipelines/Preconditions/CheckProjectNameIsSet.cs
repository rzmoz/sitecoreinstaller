namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using System;

    public class CheckProjectNameIsSet : Precondition
    {
        public override bool Evaluate(object sender, EventArgs args)
        {
            if (Services.AppSettings.ProjectNameIsSet)
                return true;
            ErrorMessage = "Project name not set. Please enter project name";
            return false;
        }
    }
}
