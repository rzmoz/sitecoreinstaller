using System;
using System.Linq;
using System.Collections.Generic;

namespace SitecoreInstaller.UI.Navigation
{
  using System.Collections;
  using System.Windows.Forms;
  using SitecoreInstaller.Framework.System;

  public class NavigationCtrlList : IEnumerable<SIButton>
  {
    private readonly Control _root;

    public NavigationCtrlList(Control root)
    {
      _root = root;
    }

    public SIButton this[string path]
    {
      get { return this.Get(_root, path); }
    }

    private SIButton Get(Control parent, string path)
    {
      if (parent == null) { throw new ArgumentNullException("parent"); }
      if (string.IsNullOrEmpty(path)) { throw new ArgumentException("provided path is null or empty"); }

      var button = parent as SIButton;
      if (button == null)
        return null;
      if (button.Path == path.ToLower())
        return button;

      foreach (Control control in parent.Controls)
      {
        var needleButton = this.Get(control, path);
        if (needleButton != null)
          return needleButton;
      }
      return null;
    }

    public void Add(SIButton button)
    {
      button.Click += this.control_Click;
      button.Activated += this.ButtonActivated;
      _root.Controls.Add(button);
      Init();
    }

    void control_Click(object sender, EventArgs e)
    {
      ButtonActivated(sender, new GenericEventArgs<SIButton>(null));
    }

    void ButtonActivated(object sender, GenericEventArgs<SIButton> e)
    {
      var button = sender as SIButton;
      if (button == null)
      {
        return;
      }

      if (e.Arg != null && sender == e.Arg)
        return;

      foreach (var button1 in this._root.Controls.OfType<SIButton>())
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

    public SIButton ActiveControl { get; private set; }

    public IEnumerator<SIButton> GetEnumerator()
    {
      return _root.Controls.OfType<SIButton>().GetEnumerator();
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
      foreach (var button in buttons.OfType<SIButton>())
      {
        button.Top = index * button.Height;
        button.Left = button.Level * button.Parent.Width;
        button.TabIndex = button.Level * 10 + index;
        button.Name = "btn" + button.Text.Replace(" ", string.Empty);
        index++;
      }
    }
  }
}
