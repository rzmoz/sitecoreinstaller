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
            ReloadConfigFile();
        }
        private void ReloadConfigFile()
        {
            _configFile = new ConfigFile(new FileInfo("Configuration/ConfigFileTest.config"));
        }

        [Test]
        public void GetMember_ReadDefaultValue_DefaultValueIsReadWhenValueIsEmpty()
        {
            var result = _configFile.WithDefaultValue;

            Assert.AreEqual("this is the default value", result);
        }

        [Test]
        public void GetMember_ReadProperty_PropertyIsReadSuccesfully()
        {
            var result = _configFile.Greeting;

            Assert.AreEqual("Hello World!", result);
        }
        [Test]
        public void GetMember_ReadProperty_PropertyNotFound()
        {
            var result = _configFile.ThisPropertyDoesNotExist;

            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void GetMember_WriteProperty_PropertyIsSet()
        {
            const string newPropertyValue = "HEllo";

            _configFile.NewProperty = newPropertyValue;
            var result = _configFile.NewProperty;
            Assert.AreEqual(newPropertyValue, result);//test from in memory
            ReloadConfigFile();
            result = _configFile.NewProperty;
            Assert.AreEqual(newPropertyValue, result);//test from disk
        }
        [Test]
        public void GetMember_UpdateProperty_PropertyIsUpdate()
        {
            const string newPropertyValue = "Hello New World!";
            const string oldPropertyValue = "Test";

            //Set initial value
            _configFile.UpdateProperty = oldPropertyValue;
            ReloadConfigFile();

            var result = _configFile.UpdateProperty;
            Assert.AreEqual(result, oldPropertyValue);//verify initial value
            _configFile.UpdateProperty = newPropertyValue;
            ReloadConfigFile();
            result = _configFile.UpdateProperty;
            Assert.AreEqual(newPropertyValue, result);
        }
    }
}
