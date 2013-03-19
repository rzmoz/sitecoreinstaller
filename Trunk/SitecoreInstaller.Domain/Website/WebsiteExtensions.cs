using System;
using System.Collections.Generic;
using System.Linq;
using SitecoreInstaller.Framework.System;

namespace SitecoreInstaller.Domain.Website
{
  using System.Diagnostics.Contracts;
  using SitecoreInstaller.Framework.Diagnostics;

  internal static class WebsiteExtensions
  {
    public static Uri ToUri(this string baseUrl, params string[] subPaths)
    {
      Contract.Requires<ArgumentNullException>(baseUrl != null);
      Contract.Requires<ArgumentNullException>(subPaths != null);

      var url = baseUrl.UrlCombine(subPaths);
      try
      {

        return new Uri("http://" + url);
      }
      catch (UriFormatException)
      {
        Log.This.Error("Invalid Uri format. Couldn't parse this: '{0}'", url);
        throw;
      }
    }
  }
}
