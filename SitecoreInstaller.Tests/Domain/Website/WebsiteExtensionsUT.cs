namespace SitecoreInstaller.Domain.Test.Website
{
    using FluentAssertions;

    using SitecoreInstaller.Domain.Website;

    using NUnit.Framework;

    [TestFixture]
    public class WebsiteExtensionsUT
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {

        }

        [Test]
        public void ToUri_UriUrlComposition_UrlIsCorrect()
        {
            const string baseUrl = "my.site.local";
            const string queryString = "?test=1";

            var paths = new[] { "folder1", "folder2" + queryString };

            var result = baseUrl.ToUri(paths);

            result.ToString().Should().Be("http://" + baseUrl + "/folder1/folder2" + queryString);
        }

        [Test]
        public void ToUri_WithSubDirs_PathIsResolved()
        {
            const string baseUrl = "base.url";
            const string path = "temp/SitecoreInstaller";

            var uri = baseUrl.ToUri(path);

            uri.ToString().Should().Be("http://" + baseUrl + "/" + path);
        }
    }
}
