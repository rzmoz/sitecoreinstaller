namespace SitecoreInstaller.UI.Navigation
{
  using System;
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

      this.TextImageRelation = TextImageRelation.ImageBeforeText;
      this.ImageAlign = ContentAlignment.MiddleLeft;
      this.TextAlign = ContentAlignment.MiddleLeft;
      this.FlatStyle = FlatStyle.Flat;
      this.FlatAppearance.BorderSize = 0;

      this.ForeColorNotSelected = this.InitColor;
      this.BackColorNotSelected = this.InitColor;
    }

    public event EventHandler<GenericEventArgs<NavButton>> Activated;
    public event EventHandler<GenericEventArgs<NavButton>> DeActivated;

    public Control TargetControl { get; private set; }


    public void Activate()
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

      if (this.TargetControl != null)
        this.TargetControl.BringToFront();

      if (this.Activated != null)
        this.Activated(this, new GenericEventArgs<NavButton>(this));
    }

    public void DeActivate()
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
        this.DeActivated(this, new GenericEventArgs<NavButton>(this));
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