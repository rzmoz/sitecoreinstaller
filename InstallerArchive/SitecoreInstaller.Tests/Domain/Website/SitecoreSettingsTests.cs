using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SitecoreInstaller.Domain.Website;

namespace SitecoreInstaller.Tests.Domain.Website
{
    [TestFixture]
    public class SitecoreSettingsTests
    {
        [Test]
        public void ToString_XmlFormat_ContentIsSitecoreConfigXml()
        {
            var setting = new SitecoreSetting("MySitecoreSetting", "SomeValue");

            var asString = setting.ToString();

            asString.Should().Be("<setting name=\"MySitecoreSetting\"><patch:attribute name=\"value\">SomeValue</patch:attribute></setting>");
        }
    }
}
