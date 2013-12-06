using System.IO;
using System.Linq;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App.Pipelines.Steps.InitialSetup
{
    public class DetermineLocalBuildLibraryFolder : Step<PipelineApplicationEventArgs>
    {
        private const string _buildLibraryFolderName = "BuildLibrary";

        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            if (Directory.Exists(Services.UserPreferences.Properties.LocalBuildLibrary))
                return;

            //we only regard fixed drives as potential targets for local drives
            var potentialDrives = DriveInfo.GetDrives().Where(drive => drive.DriveType == DriveType.Fixed);

            var existingFolderFound = false;
            foreach (var potentialDrive in potentialDrives)
            {
                var candidateFolder = Path.Combine(potentialDrive.ToString(), _buildLibraryFolderName);
                if (!Directory.Exists(candidateFolder))
                    continue;
                Services.UserPreferences.Properties.LocalBuildLibrary = candidateFolder;
                existingFolderFound = true;
            }

            if (!existingFolderFound)
            {
                Services.UserPreferences.Properties.LocalBuildLibrary = Path.Combine(@"C:\", _buildLibraryFolderName);
                new BuildLibraryFolders(Services.UserPreferences.Properties.LocalBuildLibrary).CreateIfNotExists();
            }

            Services.UserPreferences.Save();
        }
    }
}
