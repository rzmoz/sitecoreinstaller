using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Basics.IO;

namespace SitecoreInstaller.Kernel.Domain
{
    public class BuildLibraryFile : IBuildLibraryResource
    {
        public IoDir Dir { get; }
    }
}
