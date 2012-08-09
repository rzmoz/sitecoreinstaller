using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Test.WebServer
{
    using NSubstitute;

    using NUnit.Framework;

    using SitecoreInstaller.Domain.WebServer;
    using SitecoreInstaller.Framework.Diagnostics;

    [TestFixture]
    public class HostFileServiceUT
    {
        private HostFileService _hostFileService;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            var log = Substitute.For<ILog>();
            _hostFileService = new HostFileService(log);
        }

        [TestCase("test","127.0.0.1 test")]
        public void LineIsHostFileName_HostNameMatch_IsMatch(string hostFileIisSiteName, string line)
        {
            var lineIsNotHostFileName = _hostFileService.LineIsHostFileName(hostFileIisSiteName, line);

            Assert.IsTrue(lineIsNotHostFileName);
        }
        [TestCase("test","127.0.0.1 testX")]
        [TestCase("test", "127.0.0.1 Xtest")]
        [TestCase("test", "127.0.0.1 XtestX")]
        public void LineIsHostFileName_HostNameMatch_IsNotMatch(string hostFileIisSiteName, string line)
        {
            var lineIsNotHostFileName = _hostFileService.LineIsHostFileName(hostFileIisSiteName, line);

            Assert.IsFalse(lineIsNotHostFileName);
        }
    }
}
