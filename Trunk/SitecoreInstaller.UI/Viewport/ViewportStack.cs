namespace SitecoreInstaller.UI.Viewport
{
  using System.Collections.Generic;

  public static class ViewportStack
  {
    private static readonly IList<SIUserControl> _controlStack;

    static ViewportStack()
    {
      _controlStack = new List<SIUserControl>();
    }

    public static void Hide(SIUserControl control)
    {
      if (control == null)
        return;

      lock (_controlStack)
      {
        control.SendToBack();
        control.Hide();
        if (IsVisible(control))
          _controlStack.Pop();
      }
    }

    public static void OpenOrCloseDependingOnCurrentState(SIUserControl control)
    {
      if (IsVisible(control))
        Hide(control);
      else
        Show(control);
    }

    public static void Show(SIUserControl control)
    {
      if (control == null)
        return;
      lock (_controlStack)
      {
        control.Show();
        control.BringToFront();
        _controlStack.Push(control);
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
