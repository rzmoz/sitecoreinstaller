using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Forms
{
  public class SIMainDevActionButton : SIButton
  {
    public SIMainDevActionButton()
    {
      InitializeComponent();
    }
    private void InitializeComponent()
    {
      SuspendLayout();

      Size = Styles.Navigation.Level1.Size;
      Font = Styles.Fonts.H2;
      BackColor = Styles.Navigation.Level1.BackColor;
      ForeColor = Styles.Navigation.Level1.ForeColor;
      FlatAppearance.BorderSize = 0;
      FlatAppearance.MouseOverBackColor = Styles.Navigation.Level1.BackColorMouseOver;
      FlatAppearance.MouseDownBackColor = Styles.Navigation.Level1.BackColorClick;

      ResumeLayout(false);
    }
  }
}
