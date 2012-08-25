using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    public interface IPrecondition
    {
        bool Evaluate(object sender, EventArgs args);
        string ErrorMessage { get; }
    }
}
