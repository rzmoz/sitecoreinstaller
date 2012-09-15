using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.System;

    public abstract class Precondition : IPrecondition
    {
        protected Precondition()
        {
            ErrorMessage = string.Empty;
        }

        public abstract bool Evaluate(object sender, PreconditionEventArgs args);

        public string ErrorMessage { get; set; }
    }
}
