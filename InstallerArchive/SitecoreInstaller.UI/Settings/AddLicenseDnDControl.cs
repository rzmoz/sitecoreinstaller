using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Basics.Forms.DragNDrop;

namespace SitecoreInstaller.UI.Settings
{
    public class AddLicenseDnDControl : DragNDropFileControl
    {
        public AddLicenseDnDControl()
        {
            SupportedFileExtension = "xml";
        }
    }
}
