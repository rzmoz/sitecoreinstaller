using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    using SitecoreInstaller.Domain.Pipelines;

    public abstract class Precondition : IPrecondition
    {
        protected AppSettings AppSettings { get; private set; }

        protected Precondition(AppSettings appSettings)
        {
            AppSettings = appSettings;
            ErrorMessage = string.Empty;
        }

        public abstract bool Evaluate(object sender, EventArgs args);

        public string ErrorMessage { get; protected set; }
    }
}
