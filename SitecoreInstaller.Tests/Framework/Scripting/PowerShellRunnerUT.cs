using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Tests.Framework.Scripting
{
  using FluentAssertions;
  using NUnit.Framework;
  using SitecoreInstaller.Framework.Scripting;

  [TestFixture]
  public class PowerShellRunnerUT
  {
    private PowerShellRunner _psr;

    [SetUp]
    public void Setup()
    {
      _psr = new PowerShellRunner();
    }

    [Test]
    public void RunPowerShellFunction_ExecuteScript_HelloworldIsOutputted()
    {
      var result = _psr.RunPowerShellFunction("Greet", new KeyValuePair<string, object>("greetee", "World"), @".\framework\scripting\greetings.ps1");

      result.Should().Be("Hello World!");
    }
  }
}
