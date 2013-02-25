using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.UI
{
  using System.Drawing;
  using System.Windows.Forms;
  using SitecoreInstaller.Framework.System;

  public partial class SIButton : Button
  {
    private readonly Color InitColor = Color.Chartreuse; //this color equeals not set - hope no one uses this color ever!

    public SIButton()
    {
      InitializeComponent();
    }

    public event EventHandler<GenericEventArgs<SIButton>> Activated;
    public event EventHandler<GenericEventArgs<SIButton>> DeActivated;
    
    private void InitializeComponent()
    {
      SuspendLayout();

      TextImageRelation = TextImageRelation.ImageBeforeText;
      ImageAlign = ContentAlignment.MiddleLeft;
      TextAlign = ContentAlignment.MiddleLeft;
      FlatStyle = FlatStyle.Flat;
      FlatAppearance.BorderSize = 0;

      ForeColorNotSelected = InitColor;
      BackColorNotSelected = InitColor;

      ResumeLayout(false);
    }

    public void Activate()
    {
      if (BackColorNotSelected.Equals(InitColor))
      {
        BackColorNotSelected = BackColor;
        MouseOverNotSelectedColor = BackColorNotSelected;
      }

      BackColor = BackColorSelected;
      FlatAppearance.MouseOverBackColor = BackColor;

      if (ForeColorNotSelected.Equals(InitColor))
        ForeColorNotSelected = ForeColor;

      ForeColor = ForeColorSelected;

      if (ImageNotSelected == null)
        ImageNotSelected = Image;

      if (ImageSelected != null)
        Image = ImageSelected;

      if (Activated != null)
        Activated(this, new GenericEventArgs<SIButton>(this));
    }

    public void DeActivate()
    {
      if (BackColorNotSelected.Equals(InitColor))
      {
        BackColorNotSelected = BackColor;
        MouseOverNotSelectedColor = FlatAppearance.MouseOverBackColor;
      }

      FlatAppearance.MouseOverBackColor = MouseOverNotSelectedColor;
      BackColor = BackColorNotSelected;

      if (ForeColorNotSelected.Equals(InitColor))
        ForeColorNotSelected = ForeColor;

      ForeColor = ForeColorNotSelected;

      if (ImageNotSelected == null)
        ImageNotSelected = Image;

      Image = ImageNotSelected;

      if (DeActivated != null)
        DeActivated(this, new GenericEventArgs<SIButton>(this));
    }

    private Color MouseOverSelectedColor { get; set; }
    private Color MouseOverNotSelectedColor { get; set; }

    public Color ForeColorSelected { get; set; }
    private Color ForeColorNotSelected { get; set; }

    public Color BackColorSelected { get; set; }
    private Color BackColorNotSelected { get; set; }

    public Image ImageSelected { get; set; }
    private Image ImageNotSelected { get; set; }
  }
}
