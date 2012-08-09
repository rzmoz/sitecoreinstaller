using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SitecoreInstaller.Domain.Database;
using SitecoreInstaller.Framework.IO;



namespace SitecoreLocalInstallerTest.Model
{
    using NSubstitute;

    using SitecoreInstaller.Framework.Diagnostics;

    [TestFixture]
    public class SqlServiceUT
    {
        private SqlService _sqlService;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            var log = Substitute.For<ILog>();
            _sqlService = new SqlService(log);
        }

    }
}
