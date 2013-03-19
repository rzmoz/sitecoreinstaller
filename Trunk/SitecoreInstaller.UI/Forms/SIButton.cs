namespace SitecoreInstaller.UI.Forms
{
  using System.Windows.Forms;

  public class SIButton : Button
  {
    public SIButton()
    {
      this.FlatStyle = FlatStyle.Flat;
      this.FlatAppearance.BorderSize = 1;
      this.FlatAppearance.BorderColor = Styles.Fonts.Colors.Text;
      this.Font = Styles.Fonts.LblRegular;
      this.ForeColor = Styles.Fonts.Colors.Text;
    }
  }
}
