namespace SitecoreInstaller.UI.Forms
{
  using System.Windows.Forms;
  using SitecoreInstaller.Framework.Sys;

  public class SIButton : Button
  {
    public SIButton()
    {
      this.Cursor = Cursors.Hand;
      this.FlatStyle = FlatStyle.Flat;
      this.FlatAppearance.BorderSize = 1;
      this.FlatAppearance.BorderColor = Styles.Fonts.DarkBg.Colors.Text;
      this.Font = Styles.Fonts.LblRegular;
      this.ForeColor = Styles.Fonts.DarkBg.Colors.Text;
    }

    protected ToolTip ToolTip { get; private set; }

    public void Init(ToolTip toolTip)
    {
      ToolTip = toolTip;
    }

    public void SetToolTip(string text)
    {
      this.CrossThreadSafe(() =>
      {
        if (ToolTip == null || text == null)
          return;
        ToolTip.SetToolTip(this, text);
      });
    }
  }
}
