using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.UI.Forms
{
  using System.Windows.Forms;

  public class SILabel : Label
  {
    public SILabel()
    {
      this.Font = Styles.Fonts.LblRegular;
      this.ForeColor = Styles.Fonts.Colors.Text;
    }
  }
}
