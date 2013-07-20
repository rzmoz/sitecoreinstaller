namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckWritePermissionToHostFile : Precondition
    {
      public override bool InnerEvaluate(object sender, StepEventArgs args)
        {
            if (Services.IisManagement.HostFile.HasWritePermissions())
                return true;

            ErrorMessage = string.Format("SitecoreInstaller needs write permission to system host file. Run SitecoreInstaller as administrator");
            return false;
        }
    }
}
