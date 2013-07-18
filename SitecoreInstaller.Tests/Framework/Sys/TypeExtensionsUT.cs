using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Test.System
{
    using NUnit.Framework;

    using SitecoreInstaller.Framework.Sys;

    [TestFixture]
    public class TypeExtensionsUT
    {
        [Test]
        public void Is_IsType_TypeIsString()
        {
            var testType = typeof(string);
            Assert.IsTrue(testType.Is<string>());
        }
        [Test]
        public void Is_NullHanlding_TypeIsfalse()
        {
            Type testType = null;
            Assert.IsFalse(testType.Is<string>());
        }
    }
}
