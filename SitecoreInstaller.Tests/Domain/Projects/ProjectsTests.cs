using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FluentAssertions;
using NUnit.Framework;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.Projects;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Tests.Domain.Projects
{
    [TestFixture]
    public class ProjectsTests
    {
        private const string _serializedProjectSettings = @"<?xml version=""1.0"" encoding=""utf-16""?>
<ProjectSettings xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <Sitecore>MySitecore</Sitecore>
  <License>MyLicense</License>
  <Modules>
    <Module>module1</Module>
  </Modules>
  <SitecoreSettings>
    <SitecoreSetting>
      <Name>settingName1</Name>
      <Value>settingValue1</Value>
    </SitecoreSetting>
  </SitecoreSettings>
  <SqlInstallType>Client</SqlInstallType>
  <MongoInstallType>Client</MongoInstallType>
</ProjectSettings>";

        private const string _serializedProjectsettingsWithNoSitecoreSettings = @"<?xml version=""1.0""?>
<ProjectSettings xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <Sitecore>Sitecore 7.2 rev. 140123</Sitecore>
  <License>Sitecore Corporation A/S (2100-01-01)</License>
  <Modules />
  <SqlInstallType>Local</SqlInstallType>
  <MongoInstallType>Local</MongoInstallType>
</ProjectSettings>";
        
        [Test]
        public void XmlSerialize_ClassIsSerializable()
        {
            var projectSettings = new ProjectSettingsConfig
            {
                Sitecore = "MySitecore",
                License = "MyLicense",
                MongoInstallType = DbInstallType.Client,
                SqlInstallType = DbInstallType.Client,
                Modules = new List<string> { "module1" },
            };

            var asXsml = new StringBuilder();

            using (var stream = new StringWriter(asXsml))
            {
                var ser = new XmlSerializer(typeof(ProjectSettingsConfig));
                ser.Serialize(stream, projectSettings);
                stream.Close();
            }

            var serialized = asXsml.ToString();

            serialized.RemoveNewLine().Should().Be(_serializedProjectSettings.RemoveNewLine());
        }
        [Test]
        public void XmlDeSerialize_ClassIsDeSerializable()
        {

            ProjectSettingsConfig settings = null;
            using (var stream = new StringReader(_serializedProjectSettings))
            {
                var ser = new XmlSerializer(typeof(ProjectSettingsConfig));
                using (var reader = XmlReader.Create(stream))
                {
                    settings = (ProjectSettingsConfig)ser.Deserialize(reader);

                }
                stream.Close();
            }

            settings.Sitecore.Should().Be("MySitecore");
            settings.License.Should().Be("MyLicense");
            settings.MongoInstallType.Should().Be(DbInstallType.Client);
            settings.SqlInstallType.Should().Be(DbInstallType.Client);
            settings.Modules.Count.Should().Be(1);
       }

        [Test]
        public void XmlDeSerialize_MissingSitecoreSettings_ClassIsDeSerializable()
        {

            ProjectSettingsConfig settings = null;
            using (var stream = new StringReader(_serializedProjectsettingsWithNoSitecoreSettings))
            {
                var ser = new XmlSerializer(typeof(ProjectSettingsConfig));
                using (var reader = XmlReader.Create(stream))
                {
                    settings = (ProjectSettingsConfig)ser.Deserialize(reader);

                }
                stream.Close();
            }

            settings.Sitecore.Should().Be("Sitecore 7.2 rev. 140123");
            settings.License.Should().Be("Sitecore Corporation A/S (2100-01-01)");
            settings.MongoInstallType.Should().Be(DbInstallType.Local);
            settings.SqlInstallType.Should().Be(DbInstallType.Local);
            settings.Modules.Count.Should().Be(0);
        }
    }
}
