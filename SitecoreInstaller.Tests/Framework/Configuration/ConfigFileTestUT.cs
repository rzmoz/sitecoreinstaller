using System.IO;
using System.Linq;

namespace SitecoreInstaller.Tests.Framework.Configuration
{
  using System;
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
      var executingAssembly = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);

      _configFileTestFileInfo = executingAssembly.Directory.CombineTo<FileInfo>("Framework/Configuration/ConfigFileTest.config");
      _configFileTestWorkingFileInfo = executingAssembly.Directory.CombineTo<FileInfo>("Framework/Configuration/ConfigFileTestWorking.config");
    }

    [SetUp]
    public void SetUp()
    {
      _configFile = new ConfigFile<ConfigFileTest>(_configFileTestWorkingFileInfo);
      _configFile.Path.Delete();
      _configFileTestFileInfo.CopyTo(_configFile.Path.FullName);
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
      _configFile.Path.Delete();
      _configFile.Load();
      const string newPropertyValue = "HEllo";

      this._configFile.Properties.Greeting = newPropertyValue;
      this._configFile.Properties.MyCollection.Add("item 1");
      this._configFile.Properties.MyCollection.Add("item 2");
      this._configFile.Properties.MyCollection.Add("item 3");


      this._configFile.Properties.Greeting.Should().Be(newPropertyValue);//test from in memory
      _configFile.Save();
      var configFile = new ConfigFile<ConfigFileTest>(_configFile.Path);
      configFile.Properties.Greeting.Should().Be(newPropertyValue); //test from disk
      configFile.Properties.MyCollection.Count.Should().Be(3);
      configFile.Properties.MyCollection.First().Should().Be("item 1");
    }

    [Test]
    public void GetMember_UpdateProperty_PropertyIsUpdated()
    {
      const string newPropertyValue = "Hello New World!";


      this._configFile.Properties.Greeting = newPropertyValue;
      this._configFile.Save();

      var configFile = new ConfigFile<ConfigFileTest>(_configFile.Path);

      throw new ApplicationException("_configFile:"+ _configFile.Path.FullName +
                                     "\r\nconfigFile:" + configFile.Path.FullName);

      //verify that we have a new file
      configFile.Should().NotBeSameAs(this._configFile);

      //verify that propery value have been loaded from disk
      configFile.Properties.Greeting.Should().Be(newPropertyValue);
    }
  }
}
