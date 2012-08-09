namespace SitecoreInstaller.Domain.Test.Website
{
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

            Assert.AreEqual("http://" + baseUrl + "/folder1/folder2" + queryString, result.ToString());
        }
    }
}
