using System.IO;
using System.Linq;

namespace SitecoreInstaller.Tests.Framework.Configuration
{
  using System;
  using System.Reflection;
  using FluentAssertions;
  using NUnit.Framework;
  using SitecoreInstaller.Framework.Configuration;
  using SitecoreInstaller.Framework.IO;

  [TestFixture]
  public class ConfigFileTestUT
  {
    private ConfigFile<ConfigFileTest> _configFile;

    private FileInfo _configFileTestFileInfo;
    private FileInfo _configFileTestWorkingFileInfo;

    [TestFixtureSetUp]
    public void FixtureSetup()
    {
      var rootDir = Assembly.GetExecutingAssembly().Location.ToFileInfo().Directory;

      _configFileTestFileInfo = rootDir.CombineTo<FileInfo>("Framework/Configuration/ConfigFileTest.config");
      _configFileTestWorkingFileInfo = rootDir.CombineTo<FileInfo>("Framework/Configuration/ConfigFileTestWorking.config");
    }

    [SetUp]
    public void SetUp()
    {
      _configFile = new ConfigFile<ConfigFileTest>(_configFileTestWorkingFileInfo);
      _configFile.Path.Delete();
      _configFileTestFileInfo.CopyTo(_configFile.Path.FullName);
    }

    [TearDown]
    public void TearDown()
    {
      _configFileTestWorkingFileInfo.Delete();
    }

    [Test]
    public void GetMember_ReadProperty_PropertyIsReadSuccesfully()
    {
      _configFile.Load();
      var result = _configFile.Properties.Greeting;

      Assert.AreEqual("Hello World!", result);
    }

    [Test]
    public void GetMember_WriteProperty_PropertyIsSet()
    {
      _configFile.Load();
      const string newPropertyValue = "HEllo";

      _configFile.Properties.Greeting = newPropertyValue;
      _configFile.Properties.MyCollection.Clear();
      _configFile.Properties.MyCollection.Add("item 1");
      _configFile.Properties.MyCollection.Add("item 2");
      _configFile.Properties.MyCollection.Add("item 3");


      _configFile.Properties.Greeting.Should().Be(newPropertyValue);//test from in memory
      _configFile.Save();
      var configFile = new ConfigFile<ConfigFileTest>(_configFile.Path);

      configFile.FileExists.Should().BeTrue();
      configFile.Load();
      configFile.Properties.Greeting.Should().Be(newPropertyValue); //test from disk
      configFile.Properties.MyCollection.Count.Should().Be(3);
      configFile.Properties.MyCollection.First().Should().Be("item 1");

    }

    [Test]
    public void GetMember_UpdateProperty_PropertyIsUpdated()
    {
      const string newPropertyValue = "Hello New World!";

      _configFile.Properties.Greeting = newPropertyValue;
      _configFile.Save();

      var configFile = new ConfigFile<ConfigFileTest>(_configFile.Path);

      configFile.Load();

      //verify that they're looking at the same file
      _configFile.Path.Should().BeSameAs(configFile.Path);

      //verify that the file they're looking at exists
      configFile.FileExists.Should().BeTrue();

      //verify that we have a new file
      configFile.Should().NotBeSameAs(this._configFile);

      //verify that propery value have been loaded from disk
      configFile.Properties.Greeting.Should().Be(newPropertyValue);
    }
  }
}
