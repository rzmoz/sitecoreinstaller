using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.UI.Forms
{
    using System.Windows.Forms;

    public class SIH2 : Label
    {
        public SIH2()
        {
            this.Font = Styles.Fonts.H2;
            this.ForeColor = Styles.Fonts.DarkBg.Colors.Text;
        }
    }
}
