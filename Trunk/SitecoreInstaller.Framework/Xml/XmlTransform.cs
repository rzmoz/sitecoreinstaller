using System;
using System.IO;
using System.Xml;
using Microsoft.Web.Publishing.Tasks;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Framework.Xml
{
  using global::System.Diagnostics.Contracts;

  public class XmlTransform
  {
    private readonly string _transformationXml;

    public XmlTransform(FileInfo existingFile, string transformationXml)
    {
      Contract.Requires<ArgumentNullException>(existingFile != null);
      Contract.Requires<ArgumentNullException>(transformationXml != null);

      Destination = existingFile;
      Source = Destination.WithNewExtension("Source");
      Transform = Destination.WithNewExtension("Delta");
      _transformationXml = transformationXml;
    }

    public FileInfo Source { get; private set; }
    public FileInfo Transform { get; private set; }
    public FileInfo Destination { get; private set; }

    public bool Run()
    {
      if (File.Exists(Destination.FullName) == false)
        return false;

      bool flag;

      try
      {
        _transformationXml.WriteToDisk(Transform);
        Destination.CopyTo(Source.FullName, true);

        XmlTransformableDocument configFile = OpenSourceFile(Source.FullName);

        flag = new XmlTransformation(Transform.FullName).Apply(configFile);
        if (flag)
        {
          configFile.Save(Destination.FullName);
        }
      }
      catch (XmlException)
      {
        flag = false;
      }
      finally
      {
        Source.Delete();
        Transform.Delete();
      }
      return flag;
    }

    private XmlTransformableDocument OpenSourceFile(string sourceFile)
    {
      var document = new XmlTransformableDocument();
      document.Load(sourceFile);
      return document;
    }
  }
}
