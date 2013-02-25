using System;
using System.Linq;
using System.Collections.Generic;

namespace SitecoreInstaller.UI.Navigation
{
  using System.Collections;

  public class NavigationCtrlList : IEnumerable<SIButton>
  {
    private readonly SIButton _root;

    public NavigationCtrlList()
    {
      _root = new SIButton();
    }

    public SIButton this[string path]
    {
      get
      {
        return this.Get(_root, path);
      }
    }

    private SIButton Get(SIButton parent, string path)
    {
      if (parent == null) { throw new ArgumentNullException("parent"); }
      if (string.IsNullOrEmpty(path)) { throw new ArgumentException("provided path is null or empty"); }

      if (parent.Path == path.ToLower())
        return parent;

      foreach (var button1 in parent.SubButtons)
      {
        var needleButton = this.Get(button1, path);
        if (needleButton != null)
          return needleButton;
      }
      return null;
    }

    public void Add(SIButton button)
    {
      button.Click += this.control_Click;
      button.Activated += this.control_Click;
      _root.Controls.Add(button);
      Init();
    }

    void control_Click(object sender, EventArgs e)
    {
      var button = sender as SIButton;
      if (button == null)
      {
        return;
      }

      foreach (var button1 in this._root.SubButtons)
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
      return _root.SubButtons.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public void Init()
    {
      this.Init(_root.SubButtons);
    }
    private void Init(IEnumerable<SIButton> buttons)
    {
      var index = 0;
      foreach (var button in buttons)
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
