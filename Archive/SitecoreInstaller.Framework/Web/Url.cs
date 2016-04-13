using System;

namespace SitecoreInstaller.Framework.Web
{
    public class Url
    {
        private readonly string _baseUrl;
        private readonly string[] _subPaths;

        private string _protocol;


        public Url(string baseUrl, params string[] subPaths)
        {
            if (baseUrl == null) { throw new ArgumentNullException("baseUrl"); }
            if (subPaths == null) { throw new ArgumentNullException("subPaths"); }

            _baseUrl = StripProtocol(baseUrl);
            _subPaths = subPaths;
        }

        public string FullUrl
        {
            get
            {
                return _protocol + _baseUrl.UrlCombine(_subPaths);
            }
        }

        public Uri Uri
        {
            get
            {
                return new Uri(FullUrl);
            }
        }

        private string StripProtocol(string baseUrl)
        {
            var lowered = baseUrl.ToLowerInvariant();
            _protocol = "https://";
            if (lowered.StartsWith(_protocol))
                return baseUrl.Replace(_protocol, "");

            //we do this no matter if there's a protocol in the url or not
            _protocol = "http://";
            return baseUrl.Replace(_protocol, "");
        }

    }
}
