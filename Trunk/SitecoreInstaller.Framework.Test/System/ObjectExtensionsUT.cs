using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Test.System
{
    using FluentAssertions;

    using NUnit.Framework;

    using SitecoreInstaller.Framework.System;

    [TestFixture]
    public class ObjectExtensionsUT
    {
        [Test]
        public void TrySet_SetStringValue_ValueIsSet()
        {
            string property = null;
            const string value = "MyValue";
            property.TrySet(value);

            property.Should().Be(value);
        }

        [Test]
        public void TrySet_SetIntValue_ValueIsSet()
        {
            int property = 0;
            const string value = "100";
            property.TrySet(value);

            property.Should().Be(Int32.Parse(value));
        }
        [Test]
        public void TrySet_SetBoolValue_ValueIsSet()
        {
            bool property = false;
            const string value = "true";
            property.TrySet(value);

            property.Should().Be(Boolean.Parse(value));
        }
        [Test]
        public void TrySet_SetEmpty_ValueIsNotSet()
        {
            string property = null;
            const string value = "";
            property.TrySet(value);

            property.Should().BeNull();
        }
    }
}
