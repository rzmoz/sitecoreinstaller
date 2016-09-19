using System;
using FluentAssertions;
using NUnit.Framework;

namespace SitecoreInstaller.Tests
{
    [TestFixture]
    public class SitecoreVersionTests
    {
        [Test]
        //full versions
        [TestCase("Sitecore", 7, 7, "010101", "Sitecore 7.7 rev. 010101")]//full standard sitecore version 
        [TestCase("Sitecore", 7, 7, "010101_Andes", "Sitecore 7.7 rev. 010101_Andes")]//full sitecore RTI version

        //missing single
        [TestCase("Sitecore", 7, 7, null, "Sitecore 7.7")]//no revision
        [TestCase("Sitecore", 7, null, "010101", "Sitecore 7 rev. 010101")]//no minor
        [TestCase("Sitecore", null, 7, "010101", "Sitecore .7 rev. 010101")]//no major
        [TestCase(null, 7, 7, "010101", "7.7 rev. 010101")]//no name

        //missing two
        [TestCase("Sitecore", 7, null, null, "Sitecore 7")]//no minor nor revision
        [TestCase("Sitecore", null, 7, null, "Sitecore .7")]//no major nor revision
        [TestCase(null, 7, 7, null, "7.7")]//no name nor revision
        [TestCase("Sitecore", null, null, "010101", "Sitecore rev. 010101")]//no major nor minor 
        [TestCase(null, 7, null, "010101", "7 rev. 010101")]//no name nor minor 
        [TestCase(null, null, 7, "010101", ".7 rev. 010101")]//no name nor major

        //missing three
        [TestCase("Sitecore", null, null, null, "Sitecore")]//no major, minor nor revision (only name)


        //only name already covered
        [TestCase("Sitecore", null, null, null, "Sitecore")]//only name
        [TestCase(null, 7, null, null, "7")]//only major
        [TestCase(null, null, 7, null, ".7")]//only minor
        [TestCase(null, null, null, "010101", "rev. 010101")]//only revision

        //all four missing
        [TestCase(null, null, null, null, "")]//nothing
        public void ToString_FormattedAsFullVersionString_StringIsformatted(string name, int? major, int? minor, string rev, string expected)
        {
            //arrange
            var resourceVersion = new SitecoreVersion(name, major, minor, rev);

            resourceVersion.Name.Should().Be(name);
            resourceVersion.Major.Should().Be(major);
            resourceVersion.Minor.Should().Be(minor);
            resourceVersion.Revision.Should().Be(rev);

            var output = resourceVersion.ToString();

            output.Should().Be(expected);
        }

        [Test]
        [TestCase("")]//empty name
        [TestCase(null)]//name is null
        [TestCase("    ")]//name is only empty spaces
        public void Ctor_InvalidName_ExceptionIsThrown(string name)
        {
            Action act = () => { new SitecoreVersion(name); };

            act.ShouldThrow<FormatException>();
        }

        [Test]
        [TestCase("Sitecore 7.7 rev. 010101", "Sitecore", 7, 7, "010101")]//valid full string
        [TestCase("Sitecore Andes 7.7 rev. 010101", "Sitecore Andes", 7, 7, "010101")]//valid full string with space in name
        [TestCase("Sitecore 7.7", "Sitecore", 7, 7, null)]//no revision
        [TestCase("Sitecore 7.7 rev. 010101_Andes", "Sitecore", 7, 7, "010101_Andes")]//revision contains chars
        [TestCase("Sitecore 7.7 rev.010101", "Sitecore", 7, 7, "010101")]//missing space after rev. 
        [TestCase("Sitecore 7", "Sitecore", 7, null, null)]//name & major
        [TestCase("Sitecore", "Sitecore", null, null, null)]//only name
        [TestCase("Sitecore Andes", "Sitecore Andes", null, null, null)]//only name with space
        public void Ctor_ParseFullstring_StringIsParsed(string input, string expectedName, int? expectedMajor, int? expectedMinor, string expectRevision)
        {
            var resourceVersion = new SitecoreVersion(input);

            resourceVersion.Name.Should().Be(expectedName);
            resourceVersion.Major.Should().Be(expectedMajor);
            resourceVersion.Minor.Should().Be(expectedMinor);
            resourceVersion.Revision.Should().Be(expectRevision);
        }

        [Test]
        public void Set_SetPropertyIsPublic_PropertyIsSet()
        {
            const string org = "Sitecore 7.7 rev. 010101";
            const string newStringValue = "newStringValue";
            const int newIntValue = 5;

            var ver = new SitecoreVersion(org);

            ver.Name.Should().Be("Sitecore");
            ver.Name.Should().NotBe(newStringValue);
            ver.Major.Should().Be(7);
            ver.Major.Should().NotBe(newIntValue);
            ver.Minor.Should().Be(7);
            ver.Minor.Should().NotBe(newIntValue);
            ver.Revision.Should().Be("010101");
            ver.Revision.Should().NotBe(newStringValue);

            ver.Name = newStringValue;
            ver.Major = newIntValue;
            ver.Minor = newIntValue;
            ver.Revision = newStringValue;

            ver.Name.Should().Be(newStringValue);
            ver.Major.Should().Be(newIntValue);
            ver.Minor.Should().Be(newIntValue);
            ver.Revision.Should().Be(newStringValue);

            ver.ToString().Should().Be($"{newStringValue} {newIntValue}.{newIntValue} rev. {newStringValue}");

        }
    }
}

