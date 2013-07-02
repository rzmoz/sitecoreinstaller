using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using SitecoreInstaller.Domain.Pipelines;

    public class CheckBinding : Precondition
    {
        public override bool Evaluate(object sender, PreconditionEventArgs args)
        {
            if (!Services.IisManagement.BindingExists(Services.ProjectSettings.Iis.Url))
                return true;

            ErrorMessage = "Site with binding already exists: " + Services.ProjectSettings.Iis.Url;
            return false;
        }
    }
}
