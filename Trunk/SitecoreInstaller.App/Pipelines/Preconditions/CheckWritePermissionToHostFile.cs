using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    public class CheckWritePermissionToHostFile : Precondition
    {
        public override bool Evaluate(object sender, EventArgs args)
        {
            if (Services.HostFile.HasWritePermissions())
                return true;

            ErrorMessage = string.Format("SitecoreInstaller needs write permission to system host file. Run SitecoreInstaller as administrator");
            return false;
        }
    }
}
