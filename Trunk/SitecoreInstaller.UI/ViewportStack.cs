using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.UI
{
  using System.Windows.Forms;

  public static class ViewportStack
  {
    private static readonly Stack<Control> _controlStack;

    static ViewportStack()
    {
      _controlStack = new Stack<Control>();
    }

    public static void Close(Control control)
    {
      if (control == null)
        return;
      control.SendToBack();
      control.Hide();
      if (IsOnTop(control))
        _controlStack.Pop();
    }

    public static void OpenCloseDependingOnCurrentState(Control control)
    {
      if(IsOnTop(control))
        Close(control);
      else
        Open(control);
    }

    public static void Open(Control control)
    {
      control.Show();
      control.BringToFront();
      _controlStack.Push(control);
    }

    public static bool IsOnTop(Control control)
    {
      if (_controlStack.Any() == false)
        return false;

      return _controlStack.Peek() == control;
    }
  }
}
