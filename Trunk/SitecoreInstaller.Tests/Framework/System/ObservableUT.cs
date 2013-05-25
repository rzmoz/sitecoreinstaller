using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Tests.Framework.System
{
  using FluentAssertions;
  using NUnit.Framework;
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.System;

  [TestFixture]
  public class ObservableUT
  {
    private Observable<LogStatus> _primitiveObservable;

    [SetUp]
    public void Setup()
    {
      _primitiveObservable = new Observable<LogStatus>();
    }

    [Test]
    public void Updated_TriggerEvent_EventIsFired()
    {
      _primitiveObservable.MonitorEvents();
      
      _primitiveObservable.Value = LogStatus.Errors;

      _primitiveObservable.ShouldRaise("Updating");
      _primitiveObservable.ShouldRaise("Updated");
    }
  }
}
