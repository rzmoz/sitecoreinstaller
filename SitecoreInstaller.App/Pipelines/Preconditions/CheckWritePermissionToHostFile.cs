using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using SitecoreInstaller.Domain.Pipelines;

    public class CheckWritePermissionToHostFile : Precondition
    {
        public override bool Evaluate(object sender, PreconditionEventArgs args)
        {
            if (Services.IisManagement.HostFile.HasWritePermissions())
                return true;

            ErrorMessage = string.Format("SitecoreInstaller needs write permission to system host file. Run SitecoreInstaller as administrator");
            return false;
        }
    }
}
