using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.UI.Forms
{
    using System.Windows.Forms;

    public class SIH1 : Label
    {
        public SIH1()
        {
            this.Font = Styles.Fonts.H1;
            this.ForeColor = Styles.Fonts.DarkBg.Colors.H1;
        }
    }
}
