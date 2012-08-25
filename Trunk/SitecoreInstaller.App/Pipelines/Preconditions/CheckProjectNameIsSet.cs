namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using System;

    public class CheckProjectNameIsSet : Precondition
    {
        public CheckProjectNameIsSet(AppSettings appSettings)
            : base(appSettings)
        {
        }

        public override bool Evaluate(object sender, EventArgs args)
        {
            if (AppSettings.ProjectNameIsSet)
                return true;
            ErrorMessage = "Project name not set. Please enter project name";
            return false;
        }
    }
}
