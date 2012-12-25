using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.UI.Navigation
{
    using System.Drawing;
    using System.Windows.Forms;

    public class NavigationElement : UserControl
    {
        public string Title { get; set; }
        public Image Image { get; set; }
    }
}
