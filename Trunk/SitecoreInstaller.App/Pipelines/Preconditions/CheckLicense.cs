using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.Framework.Diagnostics;

    public class CheckLicense : Precondition
    {
        public override bool Evaluate(object sender, EventArgs args)
        {
            if (Services.AppSettings.UserSelections.SelectedLicense == null)
            {
                ErrorMessage = string.Format("You haven't selected a License. Please add a license in preferences pane if you have none");
                return false;
            }

            var licenseFileSourceEntry = Services.AppSettings.UserSelections.SelectedLicense as LicenseFileSourceEntry;
            if (licenseFileSourceEntry == null)
                throw new TypeLoadException("Selected license was not of expected type. Something is completely wrong with program. Get your money back! :-)");

            var licenseFile = licenseFileSourceEntry.LicenseFile;

            if (licenseFile.IsExpired)
            {
                ErrorMessage = string.Format("The selected license '{0}' has expired.\r\nPlease select another or upload a valid license.", licenseFileSourceEntry.Key);
                return false;
            }

            if (licenseFile.ExpiresWithin(UserSettings.Default.LicenseExpirationPeriodInDays))
            {
                var warningMessage = string.Format("Please mind, that the selected license '{0}' epxires in {1} days.", licenseFileSourceEntry.Key, licenseFile.ExpiresIn);
                ErrorMessage = warningMessage;
                Log.ItAs.Warning(warningMessage);
            }

            return true;
        }
    }
}
