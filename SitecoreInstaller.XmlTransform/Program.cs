using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.XmlTransform
{
  using System.Xml;
  using Microsoft.Web.Publishing.Tasks;
  using SitecoreInstaller.Framework.CmdArgs;

  class Program
  {
    static void Main(string[] args)
    {
      var cmdLine = new CmdLine();
      cmdLine.RegisterParameter(XmlTransformParameters.Source,
                                XmlTransformParameters.Delta,
                                XmlTransformParameters.Output);
      cmdLine.Parse(args);

      var source = cmdLine[XmlTransformParameters.Source].Value;
      var delta = cmdLine[XmlTransformParameters.Delta].Value;
      var output = cmdLine[XmlTransformParameters.Output].Value;

      try
      {
        XmlTransformableDocument configFile = OpenSourceFile(source);

        bool trannsformWasSuccessful = new XmlTransformation(delta).Apply(configFile);
        if (trannsformWasSuccessful)
        {
          configFile.Save(output);
          Console.WriteLine("Xml transformed");
        }
        else
          Console.Error.Write("Transform not successful");
      }
      catch (XmlException e)
      {
        Console.Error.Write(e.ToString());
      }
    }

    private static XmlTransformableDocument OpenSourceFile(string sourceFile)
    {
      var document = new XmlTransformableDocument();
      document.Load(sourceFile);
      return document;
    }
  }
}
