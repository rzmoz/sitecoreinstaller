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
        private string _errorMessage;

        protected Precondition()
        {
            _errorMessage = string.Empty;
        }

        public abstract bool Evaluate(object sender, EventArgs args);

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;

                if (string.IsNullOrEmpty(_errorMessage))
                    return;
                Log.As.Error(_errorMessage);
            }
        }
    }
}
