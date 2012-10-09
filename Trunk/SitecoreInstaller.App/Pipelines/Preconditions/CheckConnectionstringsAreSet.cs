using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.UI;

    public class CheckConnectionstringsAreSet : IPrecondition
    {
        public bool Evaluate(object sender, PreconditionEventArgs args)
        {
            if(Services.ProjectSettings.InstallType == InstallType.Full)
                return true;

            if (Services.ProjectSettings.InstallType == InstallType.Client)
            {
                using (var selectDatabases = new SelectDatabases())
                {
                    var result = selectDatabases.ShowDialog();
                }
            }
            return true;
        }

        public string ErrorMessage
        {
            get { return ""; }
        }
    }
}
