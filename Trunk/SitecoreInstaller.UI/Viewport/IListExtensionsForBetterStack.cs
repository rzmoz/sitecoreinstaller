using System;
using System.Collections.Generic;
using System.Linq;

namespace SitecoreInstaller.UI.Viewport
{
  internal static class IListExtensionsForBetterStack
  {
    public static T Pop<T>(this IList<T> list)
    {
      AssertListHasElements(list);

      var item = list.First();
      list.RemoveAt(0);
      return item;
    }

    public static T Peek<T>(this IList<T> list, int peekAt = 0)
    {
      AssertListHasElements(list);
      if (list.Count > peekAt)
        return list[peekAt];
      throw new InvalidOperationException("no element at index:" + peekAt);
    }

    public static void Push<T>(this IList<T> list, T t)
    {
      if (list == null) { throw new ArgumentNullException("list"); }
      list.Insert(0, t);
    }
    
    private static void AssertListHasElements<T>(IEnumerable<T> list)
    {
      if (list == null)
      {
        throw new ArgumentNullException("list");
      }
      if (list.Any() == false)
      {
        throw new InvalidOperationException("No elements in stack");
      }
    }


  }
}
