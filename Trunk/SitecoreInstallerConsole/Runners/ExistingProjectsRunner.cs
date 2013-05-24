using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstallerConsole.Runners
{
  using SitecoreInstaller.App;

  public class ExistingProjectsRunner : ConsolePipelineRunner
  {
    public ExistingProjectsRunner() 
    {
      CmdLine.RegisterParameter(SitecoreInstallerParameters.Projects);
    }

    public override void Run()
    {
      Console.WriteLine(string.Empty);
      Console.WriteLine("**** Existing projects *********************");
      Console.WriteLine(string.Empty);
      foreach (var project in Services.Projects.GetExistingProjects())
      {
        Console.WriteLine("{0}", project.Name);
      }
      Console.WriteLine(string.Empty);
    }
  }
}
