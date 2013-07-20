using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
  using SitecoreInstaller.Framework.Linguistics;

  public interface IPrecondition
  {
    Sentence Name { get; }
    bool Evaluate(object sender, EventArgs args);
    string ErrorMessage { get; }
  }
}
