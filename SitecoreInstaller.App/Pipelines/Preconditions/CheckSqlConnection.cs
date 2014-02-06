using SitecoreInstaller.Domain;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    public class CheckSqlConnection : Precondition<PipelineApplicationEventArgs>
    {
        public override bool InnerEvaluate(object sender, PipelineApplicationEventArgs args)
        {
            //we don't verify sql settings on client install
            if (args.ProjectSettings.Sql.InstallType == DbInstallType.Client)
                return true;

            if (args.ProjectSettings.Sql.TestConnection())
                return true;
            ErrorMessage = "Sql settings are not properly set. Check under preferences";
            return false;
        }
    }
}
