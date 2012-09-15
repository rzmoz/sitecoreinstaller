using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Test.Configuration
{
    using NUnit.Framework;

    using SitecoreInstaller.Framework.Configuration;

    using global::System.IO;

    [TestFixture]
    public class ConfigFileUT
    {
        private dynamic _configFile;

        [SetUp]
        public void SetUp()
        {
            _configFile = new ConfigFile(new FileInfo("Configuration/ConfigFileTest.config"));
        }

        [Test]
        public void GetMember_ReadProperty_PropertyIsReadSuccesfully()
        {
            var result = _configFile.Greeting;

            Assert.AreEqual(result, "Hello World!");
        }
        [Test]
        public void GetMember_ReadProperty_PropertyNotFound()
        {
            var result = _configFile.ThisPropertyDoesNotExist;

            Assert.AreEqual(null, result);
        }
    }
}
