namespace SitecoreInstaller.UI.Viewport
{
  using System.Collections.Generic;
  using System.Linq;

  public static class ViewportStack
  {
    private static readonly IList<SIUserControl> _controlStack;
    private static readonly ISet<SIUserControl> _registeredControls;

    static ViewportStack()
    {
      _controlStack = new List<SIUserControl>();
      _registeredControls = new HashSet<SIUserControl>();
    }

    public static SIUserControl ActiveCtrl
    {
      get
      {
        foreach (var siUserControl in _controlStack)
        {
          if (siUserControl.BlocksView)
            return siUserControl;
        }
        return null;
      }
    }

    public static void Register(SIUserControl ctrl)
    {
      lock (_registeredControls)
      {
        if (_registeredControls.Contains(ctrl))
          return;
        _registeredControls.Add(ctrl);
      }
    }

    public static void UnRegister(SIUserControl ctrl)
    {
      lock (_registeredControls)
      {
        if (_registeredControls.Contains(ctrl))
          _registeredControls.Remove(ctrl);
      }
    }

    public static void Hide(SIUserControl control)
    {
      if (control == null)
        return;

      lock (_controlStack)
      {
        if (_controlStack.Contains(control) == false)
          return;

        control.SendToBack();
        control.Hide();
        _controlStack.Remove(control);
        if (_controlStack.Any())
          _controlStack.Peek().Show();
      }
    }

    public static bool OpenOrCloseDependingOnCurrentState(SIUserControl control)
    {
      if (IsVisible(control))
        Hide(control);
      else
        Show(control);
      return IsVisible(control);
    }

    public static void Show(string controlKey)
    {
      if (string.IsNullOrEmpty(controlKey))
        return;
      var control = _registeredControls.FirstOrDefault(ctrl => ctrl.GetType().ToString() == controlKey);
      Show(control);
    }

    public static void Show(SIUserControl control)
    {
      if (control == null)
        return;

      lock (_controlStack)
      {
        if (IsVisible(control))
          return;
        control.Show();
        control.BringToFront();
        _controlStack.Remove(control);
        _controlStack.Push(control);
        control.OnShow();
      }
    }

    public static bool IsVisible(SIUserControl control)
    {
      if (control == null)
        return false;

      if (_controlStack.Contains(control) == false)
        return false;

      int peekAt = 0;
      SIUserControl lookingAt = null;
      do
      {
        lookingAt = _controlStack.Peek(peekAt++);
        if (lookingAt == control)
          return true;
      }
      while (lookingAt.BlocksView == false);
      return false;
    }
  }
}
