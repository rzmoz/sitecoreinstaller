using System;
using NUnit.Framework;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Tests.Framework.Sys
{
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
