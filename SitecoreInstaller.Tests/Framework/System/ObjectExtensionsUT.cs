using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Test.System
{
    using FluentAssertions;

    using NUnit.Framework;

    using SitecoreInstaller.Framework.Sys;

    [TestFixture]
    public class ObjectExtensionsUT
    {
        [Test]
        public void TrySet_SetStringValue_ValueIsSet()
        {
            string property = null;
            const string value = "MyValue";
            property = property.TrySet(value);

            property.Should().Be(value);
        }

        [Test]
        public void TrySet_SetIntValue_ValueIsSet()
        {
            int property = 0;
            const string value = "100";
            property = property.TrySet(value);

            property.Should().Be(Int32.Parse(value));
        }
        [Test]
        public void TrySet_SetBoolValue_ValueIsSet()
        {
            bool property = false;
            const string value = "true";
            property = property.TrySet(value);

            property.Should().Be(Boolean.Parse(value));
        }
        [Test]
        public void TrySet_SetEmpty_ValueIsSet()
        {
            string property = null;
            const string value = "";
            property = property.TrySet(value, true);

            property.Should().BeEmpty();
        }

        [Test]
        public void TrySet_DoNotSet_ValueIsNotSet()
        {
            string initialValue = "not null";

            string property = initialValue;
            const string value = "";
            property = property.TrySet(value);

            property.Should().Be(initialValue);
        }
    }
}
