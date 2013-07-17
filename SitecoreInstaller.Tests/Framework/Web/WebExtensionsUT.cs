using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Tests.Framework.Web
{
  using FluentAssertions;
  using NUnit.Framework;
  using SitecoreInstaller.Framework.Web;

  [TestFixture]
  public class WebExtensionsUT
  {
    [Test]
    public void ToUri_WithHttpInFront_UriIsParsed()
    {
      const string url = "http://www.google.com";

      var result = url.ToUri();

      var expected = new Uri(url);

      result.AbsoluteUri.Should().Be(expected.AbsoluteUri);
    }

    [Test]
    public void ToUri_WithoutHttpInFront_UriIsParsed()
    {
      const string url = "google.com";

      var result = url.ToUri();

      var expected = new Uri("http://" + url);

      result.AbsoluteUri.Should().Be(expected.AbsoluteUri);
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



    [Test]
    public void UrlCombine_PathCombination_PathIsCombinedAndSeperatedBySlash()
    {
      const string root = "root";
      const string expected = "root/part1/part2/part3";
      var result = root.UrlCombine("part1", "part2", "part3");

      result.Should().Be(expected);
    }
    [Test]
    public void UrlCombine_TrickyPathCombination_PathIsCombinedAndSeperatedBySlash()
    {
      const string root = "root.sc.local/";
      const string expected = @"root.sc.local/part1/part2/part3";
      var result = root.UrlCombine(@"//part1\part2///part3");

      result.Should().Be(expected);
    }
  }
}
