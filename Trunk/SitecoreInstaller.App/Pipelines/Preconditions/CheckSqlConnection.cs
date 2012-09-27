using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using SitecoreInstaller.Domain.Pipelines;

    public class CheckSqlConnection : Precondition
    {
        public override bool Evaluate(object sender, PreconditionEventArgs args)
        {
            if (Services.ProjectSettings.Sql.TestConnection())
                return true;

            ErrorMessage = "Error when connecting to SQL server. Check sql settings under Preferences";
            return false;
        }
    }
}
