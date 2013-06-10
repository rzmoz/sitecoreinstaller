using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.UI.Navigation
{
  using System.Windows.Forms;

  public class Level1NavigationButton : NavButton
  {
    public Level1NavigationButton(Control targetControl)
      : base(targetControl)
    {
      this.InitializeComponent();
    }
    
    private void InitializeComponent()
    {
      SuspendLayout();

      Size = Styles.Navigation.Level1.Size;
      Font = Styles.Fonts.H2;
      BackColor = Styles.Navigation.Level1.BackColor;
      BackColorSelected = Styles.Navigation.Level1.BackColorSelected;
      ForeColor = Styles.Navigation.Level1.ForeColor;
      ForeColorSelected = Styles.Navigation.Level1.ForeColorSelected;

      FlatAppearance.MouseOverBackColor = Styles.Navigation.Level1.BackColorMouseOver;
      FlatAppearance.MouseDownBackColor = Styles.Navigation.Level1.BackColorClick;

      ResumeLayout(false);
    }
  }
}
