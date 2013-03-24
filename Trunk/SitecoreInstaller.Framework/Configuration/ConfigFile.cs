using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System;

namespace SitecoreInstaller.Framework.Configuration
{
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.IO;

  public sealed class ConfigFile<T> where T : IConfig, new()
  {
    public ConfigFile(FileInfo path)
    {
      this.Path = path;
      this.Properties = new T();
      if (Path.Exists)
        this.Load();
    }

    public T Properties { get; private set; }
    public FileInfo Path { get; set; }
    public bool Exists { get { return File.Exists(Path.FullName); } }

    public void Load()
    {
      if (Path == null)
        throw new NotSupportedException("Path is not set");

      if (File.Exists(Path.FullName) == false)
      {
        this.Properties = new T();
      }

      try
      {
        var ser = new XmlSerializer(typeof(T));
        using (var reader = XmlReader.Create(Path.FullName))
        {
          var configFile = (T)ser.Deserialize(reader);
          this.Properties = configFile;
        }
      }
      catch (Exception e)
      {

        Log.This.Error(e.ToString());
      }
    }

    public void Save()
    {
      if (Path == null)
        throw new NotSupportedException("Path is not set");

      Path.Directory.CreateIfNotExists();

      try
      {
        using (var fileStream = new FileStream(Path.FullName, FileMode.Create))
        {
          var ser = new XmlSerializer(this.Properties.GetType());
          ser.Serialize(fileStream, this.Properties);
          fileStream.Close();
        }
      }
      catch (Exception e)
      {
        Log.This.Error(e.ToString());
      }
    }
  }
}