using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System;
using CSharp.Basics.Sys;
using SitecoreInstaller.Framework.Diagnostics;
using CSharp.Basics.IO;

namespace SitecoreInstaller.Framework.Configuration
{
    public sealed class ConfigFile<T> where T : IConfig, new()
    {
        public event EventHandler<GenericEventArgs<T>> Updated;

        public ConfigFile(FileInfo path)
        {
            Path = path;
            Properties = new T();
            if (Path.Exists)
                Load();
        }

        public T Properties { get; private set; }
        public FileInfo Path { get; set; }
        public bool FileExists { get { return File.Exists(Path.FullName); } }

        public void Init()
        {
            Updated = null;
        }

        public void Load()
        {
            if (Path == null)
                throw new NotSupportedException("Path is not set");

            if (!FileExists)
            {
                Log.As.Error("Config file not found. Looking for: " + Path.FullName);
                return;
            }

            try
            {
                var ser = new XmlSerializer(typeof(T));
                using (var reader = XmlReader.Create(Path.FullName))
                {
                    var configFile = (T)ser.Deserialize(reader);
                    Properties = configFile;
                }
            }
            catch (Exception e)
            {
                //TODO: Replace with somethin not relying on app being up and running
                //Log.ToDebugFile.Error("Failed to load: {0}\r\n{1}", Path.FullName, e.ToString());
            }

            if (Updated != null)
                Updated(this, new GenericEventArgs<T>(Properties));
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
                //TODO: Replace with somethin not relying on app being up and running
                //Log.ToDebugFile.Error(e.ToString());
            }
            if (Updated != null)
                Updated(this, new GenericEventArgs<T>(Properties));
        }
    }
}