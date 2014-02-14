using System.IO;
using System.Linq;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.App.Pipelines.Steps.AutoSetup
{
    public class DetermineLocalBuildLibraryFolder : Step<PipelineApplicationEventArgs>
    {
        private const string _buildLibraryFolderName = "BuildLibrary";

        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            if (Directory.Exists(Services.UserPreferences.Properties.LocalBuildLibrary))
                return;

            //we only regard fixed drives as potential targets for local drives
            var potentialDrives = DriveInfo.GetDrives().Where(drive => drive.DriveType == DriveType.Fixed).OrderBy(drive => drive.Name);

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
                Services.UserPreferences.Properties.LocalBuildLibrary = potentialDrives.First().RootDirectory.Combine(_buildLibraryFolderName).FullName;
                new BuildLibraryFolders(Services.UserPreferences.Properties.LocalBuildLibrary).CreateIfNotExists();
            }

            Services.UserPreferences.Save();
        }
    }
}
