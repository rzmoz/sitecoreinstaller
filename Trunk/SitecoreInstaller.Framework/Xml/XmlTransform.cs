using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                return true;//should this be true or false?

            bool flag = true;

            try
            {
                _transformationXml.WriteToDisk(Transform);
                Destination.CopyTo(Source.FullName, true);

                XmlTransformableDocument xmlTarget = OpenSourceFile(Source.FullName);

                flag = new XmlTransformation(Transform.FullName).Apply(xmlTarget);
                if (flag)
                {
                    xmlTarget.Save(Destination.FullName);
                }
            }
            catch (XmlException)
            {
                flag = false;
            }
            finally
            {
                try
                {
                    if (File.Exists(Source.FullName))
                        Source.Delete();
                    if (File.Exists(Transform.FullName))
                        Transform.Delete();
                }
                catch (Exception)
                { }

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
