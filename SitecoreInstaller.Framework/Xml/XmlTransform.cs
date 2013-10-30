using System.IO;
using SitecoreInstaller.Framework.IO;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Framework.Xml
{
  public static class XmlTransform
  {
    private const string _FileName = "SitecoreInstaller.XmlTransform.exe";
    private const string _TransformFormat = _FileName + @" -source ""{0}"" -delta ""{1}"" -output ""{2}""";

    public static bool Transform(FileInfo existingFile, string transformationXml)
    {
      if (existingFile.Exists() == false)
        return false;

      var output = existingFile;
      var source = output.WithNewExtension("Source");
      var delta = output.WithNewExtension("Delta");

      transformationXml.WriteToDisk(delta);
      output.CopyTo(source.FullName, true);

      var result = CommandPrompt.Run(_TransformFormat, source.FullName, delta.FullName, output.FullName);
      
      source.Delete();
      delta.Delete();

      return string.IsNullOrEmpty(result.StandardError);
    }
  }
}
