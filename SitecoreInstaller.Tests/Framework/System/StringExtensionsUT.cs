using Enumerable = System.Linq.Enumerable;

namespace SitecoreInstaller.Tests.Framework.System
{
  using NUnit.Framework;
  using SitecoreInstaller.Framework.System;
  using FluentAssertions;

  [TestFixture]
  public class StringExtensionsUT
  {
    [Test]
    [TestCase("ct3translation", 1)]
    public void TokenizeWhenCharIsUpper_TokenizeWhenCharIsUpper_StringIsTokenized(string input, int expectedTokens)
    {
      var result = input.TokenizeWhenCharIsUpper();
      expectedTokens.Should().Be(Enumerable.Count(result));
    }

    [Test]
    public void UrlCombine_PathCombination_PathIsCombinedAndSeperatedBySlash()
    {
      const string root = "root";
      const string expected = "root/part1/part2/part3";
      var result = root.UrlCombine("part1", "part2", "part3");

      expected.Should().Be(result);
    }
    [Test]
    public void UrlCombine_TrickyPathCombination_PathIsCombinedAndSeperatedBySlash()
    {
      const string root = "root.sc.local/";
      const string expected = @"root.sc.local/part1/part2/part3";
      var result = root.UrlCombine(@"//part1\part2///part3");

      expected.Should().Be(result);
    }
  }
}