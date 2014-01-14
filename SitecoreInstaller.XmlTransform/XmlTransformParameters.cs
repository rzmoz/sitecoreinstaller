using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.CmdArgs;

namespace SitecoreInstaller.XmlTransform
{
    public static class XmlTransformParameters
    {
        public static CmdLineParameter Source { get { return new CmdLineParameter("source", "Source file") { Required = true, AllowEmptyValue = false }; } }
        public static CmdLineParameter Delta { get { return new CmdLineParameter("delta", "Delta file") { Required = true, AllowEmptyValue = false }; } }
        public static CmdLineParameter Output { get { return new CmdLineParameter("output", "Output file") { Required = true, AllowEmptyValue = false }; } }
    }
}
