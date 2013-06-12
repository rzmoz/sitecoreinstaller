using System;

namespace SitecoreInstaller.UI.Forms
{
  using System.Drawing;
  using System.Windows.Forms;
  using SitecoreInstaller.Framework.System;

  public class SIButtonWithActiveState : SIButton
  {
    private readonly Color InitColor = Color.Chartreuse; //this color equals not set - hope no one uses this color ever!

    public SIButtonWithActiveState()
    {
      this.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.ImageAlign = ContentAlignment.MiddleLeft;
      this.TextAlign = ContentAlignment.MiddleLeft;
      this.FlatAppearance.BorderSize = 0;

      this.ForeColorNotSelected = this.InitColor;
      this.BackColorNotSelected = this.InitColor;
    }

    public event EventHandler<GenericEventArgs<SIButtonWithActiveState>> Activated;
    public event EventHandler<GenericEventArgs<SIButtonWithActiveState>> DeActivated;

    public virtual void Activate()
    {
      if (this.BackColorNotSelected.Equals(this.InitColor))
      {
        this.BackColorNotSelected = this.BackColor;
        this.MouseOverNotSelectedColor = this.BackColorNotSelected;
      }

      this.BackColor = this.BackColorSelected;
      this.FlatAppearance.MouseOverBackColor = this.BackColor;

      if (this.ForeColorNotSelected.Equals(this.InitColor))
        this.ForeColorNotSelected = this.ForeColor;

      this.ForeColor = this.ForeColorSelected;

      if (this.ImageNotSelected == null)
        this.ImageNotSelected = this.Image;

      if (this.ImageSelected != null)
        this.Image = this.ImageSelected;

      if (this.Activated != null)
        this.Activated(this, new GenericEventArgs<SIButtonWithActiveState>(this));
    }

    public virtual void DeActivate()
    {
      if (this.BackColorNotSelected.Equals(this.InitColor))
      {
        this.BackColorNotSelected = this.BackColor;
        this.MouseOverNotSelectedColor = this.FlatAppearance.MouseOverBackColor;
      }

      this.FlatAppearance.MouseOverBackColor = this.MouseOverNotSelectedColor;
      this.BackColor = this.BackColorNotSelected;

      if (this.ForeColorNotSelected.Equals(this.InitColor))
        this.ForeColorNotSelected = this.ForeColor;

      this.ForeColor = this.ForeColorNotSelected;

      if (this.ImageNotSelected == null)
        this.ImageNotSelected = this.Image;

      this.Image = this.ImageNotSelected;

      if (this.DeActivated != null)
        this.DeActivated(this, new GenericEventArgs<SIButtonWithActiveState>(this));
    }

    private Color MouseOverNotSelectedColor { get; set; }

    public Color ForeColorSelected { get; set; }
    private Color ForeColorNotSelected { get; set; }

    public Color BackColorSelected { get; set; }
    private Color BackColorNotSelected { get; set; }

    public Image ImageSelected { get; set; }
    private Image ImageNotSelected { get; set; }

  }
}
