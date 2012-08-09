using System;
using System.Collections.Generic;
using System.Linq;
using SitecoreInstaller.Framework.System;

namespace SitecoreInstaller.Domain.Website
{
    using System.Diagnostics.Contracts;

    internal static class WebsiteExtensions
    {
        public static Uri ToUri(this string baseUrl, params string[] subPaths)
        {
            Contract.Requires<ArgumentNullException>(baseUrl != null);
            Contract.Requires<ArgumentNullException>(subPaths != null);

            var url = baseUrl.UrlCombine(subPaths);
            return new Uri("http://" + url);
        }
    }
}
