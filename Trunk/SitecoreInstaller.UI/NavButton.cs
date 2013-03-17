using System;

namespace SitecoreInstaller.UI
{
  using System.Collections.Generic;
  using System.Drawing;
  using System.Linq;
  using System.Windows.Forms;
  using SitecoreInstaller.Framework.System;

  public class NavButton : Button
  {
    private readonly Color InitColor = Color.Chartreuse; //this color equals not set - hope no one uses this color ever!

    public NavButton(Control targetControl)
    {
      if (targetControl == null) { throw new ArgumentNullException("targetControl"); }
      this.TargetControl = targetControl;

      TextImageRelation = TextImageRelation.ImageBeforeText;
      ImageAlign = ContentAlignment.MiddleLeft;
      TextAlign = ContentAlignment.MiddleLeft;
      FlatStyle = FlatStyle.Flat;
      FlatAppearance.BorderSize = 0;

      ForeColorNotSelected = InitColor;
      BackColorNotSelected = InitColor;
    }

    public event EventHandler<GenericEventArgs<NavButton>> Activated;
    public event EventHandler<GenericEventArgs<NavButton>> DeActivated;

    public Control TargetControl { get; private set; }


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

      if (this.TargetControl != null)
        this.TargetControl.BringToFront();

      if (Activated != null)
        Activated(this, new GenericEventArgs<NavButton>(this));
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
        DeActivated(this, new GenericEventArgs<NavButton>(this));
    }

    private Color MouseOverNotSelectedColor { get; set; }

    public Color ForeColorSelected { get; set; }
    private Color ForeColorNotSelected { get; set; }

    public Color BackColorSelected { get; set; }
    private Color BackColorNotSelected { get; set; }

    public Image ImageSelected { get; set; }
    private Image ImageNotSelected { get; set; }


    #region tree methods

    public string Path
    {
      get
      {
        return this.GetPath(this);
      }
    }

    private string GetPath(NavButton button)
    {
      if (button == null)
        return string.Empty;

      var myPath = "/" + button.Text.ToLower().Replace(" ", string.Empty);

      if (button.IsRoot)
        return myPath;

      return button.GetPath(button.ParentButton) + myPath;
    }

    public IEnumerable<NavButton> GetAllDescendants()
    {
      return this.GetAllDescendants(this);
    }

    private IEnumerable<NavButton> GetAllDescendants(NavButton button)
    {
      return button.SubButtons.SelectMany(subButton => subButton.GetAllDescendants(subButton));
    }


    /// <summary>
    /// zero based
    /// </summary>
    public int Level
    {
      get { return this.GetLevel(this); }
    }

    private int GetLevel(NavButton button)
    {
      if (button.IsRoot || button.ParentButton.IsRoot)
        return 0;
      return 1 + this.GetLevel(this.ParentButton);
    }

    public IEnumerable<NavButton> SubButtons
    {
      get { return this.Controls.OfType<NavButton>(); }
    }

    public NavButton ParentButton
    {
      get { return this.Parent as NavButton; }
    }

    public bool IsRoot
    {
      get { return this.ParentButton == null; }
    }

    #endregion
  }
}