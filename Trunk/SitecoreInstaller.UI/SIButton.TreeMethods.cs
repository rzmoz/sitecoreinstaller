using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.UI
{
  public partial class SIButton
  {
    public string Path
    {
      get { return this.GetPath(this); }
    }

    /// <summary>
    /// zero based
    /// </summary>
    public int Level
    {
      get { return this.GetLevel(this); }
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

    private string GetPath(SIButton button)
    {
      if (button.IsRoot)
        return string.Empty;

      var myPath = "/" + Text.ToLower().Replace(" ", string.Empty);

      return this.GetPath((SIButton)button.Parent) + myPath;
    }

    private int GetLevel(SIButton button)
    {
      if (button.IsRoot || button.ParentButton.IsRoot)
        return 0;
      return 1 + this.GetLevel(this.ParentButton);
    }
  }
}
