using System;
using System.Linq;
using System.Collections.Generic;

namespace SitecoreInstaller.UI.Navigation
{
  using System.Collections;
  using System.Windows.Forms;
  using SitecoreInstaller.Framework.Sys;
  using SitecoreInstaller.UI.Forms;

  public class NavigationCtrlList : IEnumerable<NavButton>
  {
    private readonly ToolTip _toolTip;
    private readonly Control _root;
    private readonly int _topOffset;

    public NavigationCtrlList(Control root, int topOffset = 0, ToolTip toolTip = null)
    {
      _toolTip = toolTip;
      _root = root;
      _topOffset = topOffset;
    }

    public NavButton this[string path]
    {
      get { return this.Get(_root, path); }
    }

    private NavButton Get(Control parent, string path)
    {
      if (parent == null) { throw new ArgumentNullException("parent"); }
      if (string.IsNullOrEmpty(path)) { throw new ArgumentException("provided path is null or empty"); }

      var button = parent as NavButton;
      if (button != null && button.Path == path.ToLower())
        return button;

      foreach (Control control in parent.Controls)
      {
        var needleButton = this.Get(control, path);
        if (needleButton != null)
          return needleButton;
      }
      return null;
    }

    public void Add(NavButton button)
    {
      button.Click += this.control_Click;
      button.Activated += this.ButtonActivated;
      _root.Controls.Add(button);
      Init();
    }

    void control_Click(object sender, EventArgs e)
    {
      ButtonActivated(sender, new GenericEventArgs<SIButtonWithActiveState>(null));
    }

    void ButtonActivated(object sender, GenericEventArgs<SIButtonWithActiveState> e)
    {
      var button = sender as NavButton;
      if (button == null)
      {
        return;
      }

      if (e.Arg != null && sender == e.Arg)
        return;

      foreach (var button1 in this._root.Controls.OfType<NavButton>())
      {
        button1.DeActivate();
      }
      button.Activate();

      this.ActiveControl = button;
    }

    public void Remove(string path)
    {
      var button = this[path];

      if (button == null)
        return;

      button.Parent.Controls.Remove(button);
      Init();
    }

    public NavButton ActiveControl { get; private set; }

    public IEnumerator<NavButton> GetEnumerator()
    {
      return _root.Controls.OfType<NavButton>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public void Init()
    {
      this.Init(_root.Controls.Cast<Control>());
    }

    private void Init(IEnumerable<Control> buttons)
    {
      var index = 0;
      foreach (var button in buttons.OfType<NavButton>())
      {
        button.Top = index * button.Height + _topOffset;
        button.Left = button.Level * button.Parent.Width;
        button.TabIndex = button.Level * 10 + index;
        button.Name = "btn" + button.Text.Replace(" ", string.Empty);
        if (_toolTip != null)
          _toolTip.SetToolTip(button, button.Text);
        index++;
      }
    }
  }
}
