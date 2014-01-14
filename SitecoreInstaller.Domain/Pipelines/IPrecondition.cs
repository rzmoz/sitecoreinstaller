using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SitecoreInstaller.Framework.Linguistics;

namespace SitecoreInstaller.Domain.Pipelines
{
    public interface IPrecondition
    {
        Sentence Name { get; }
        bool Evaluate(object sender, EventArgs args);
        string ErrorMessage { get; }
    }
}
