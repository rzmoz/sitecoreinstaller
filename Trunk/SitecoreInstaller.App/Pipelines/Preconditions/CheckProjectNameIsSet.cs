namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using System;

    public class CheckProjectNameIsSet : Precondition
    {
        public CheckProjectNameIsSet(Func<AppSettings> getAppSettings)
            : base(getAppSettings)
        {
        }

        public override bool Evaluate(object sender, EventArgs args)
        {
            if (GetAppSettings().ProjectNameIsSet)
                return true;
            ErrorMessage = "Project name not set. Please enter project name";
            return false;
        }
    }
}
