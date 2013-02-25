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

    private string GetPath(SIButton button)
    {
      var myPath = "/" + button.Text.ToLower().Replace(" ", string.Empty);

      return button.GetPath((SIButton)button.Parent) + myPath;
    }

    public IEnumerable<SIButton> GetAllDescendants()
    {
      return this.GetAllDescendants(this);
    }

    private IEnumerable<SIButton> GetAllDescendants(SIButton button)
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

    private int GetLevel(SIButton button)
    {
      if (button.IsRoot || button.ParentButton.IsRoot)
        return 0;
      return 1 + this.GetLevel(this.ParentButton);
    }

    public IEnumerable<SIButton> SubButtons
    {
      get
      {
        return this.Controls.OfType<SIButton>();
      }
    }

    public SIButton ParentButton
    {
      get { return this.Parent as SIButton; }
    }

    public bool IsRoot
    {
      get { return this.ParentButton == null; }
    }
  }
}
