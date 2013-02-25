using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.UI
{
  using System.Drawing;
  using System.Windows.Forms;
  using SitecoreInstaller.Framework.System;

  public class SIButton : Button
  {
    private readonly Color InitColor = Color.Chartreuse; //this color equeals not set - hope no one uses this color ever!

    public SIButton()
    {
      InitializeComponent();
    }

    public event EventHandler<GenericEventArgs<SIButton>> Activated;
    public event EventHandler<GenericEventArgs<SIButton>> DeActivated;

    public string Path
    {
      get { return this.GetPath(this); }
    }
    private string GetPath(SIButton button)
    {
      if (button.IsRoot)
        return string.Empty;

      var myPath = "/" + Text.ToLower().Replace(" ", string.Empty);

      return this.GetPath((SIButton)button.Parent) + myPath;
    }

    /// <summary>
    /// zero based
    /// </summary>
    public int Level
    {
      get { return this.GetLevel(this); }
    }

    private int GetLevel(SIButton button)
    {
      if (button.IsRoot || button.ParentButton.IsRoot)
        return 0;
      return 1 + this.GetLevel(this.ParentButton);
    }

    public IEnumerable<SIButton> SubButtons
    {
      get { return this.Controls.OfType<SIButton>(); }
    }
    public SIButton ParentButton
    {
      get { return this.Parent as SIButton; }
    }
    public bool IsRoot
    {
      get
      {
        if (this.Name.Length == 0)
          return true;
        if (this.Parent == null)
          return true;
        if (this.Parent as SIButton == null)
          return true;
        return false;
      }
    }



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
