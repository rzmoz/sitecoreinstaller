using Enumerable = System.Linq.Enumerable;

namespace SitecoreInstaller.Tests.Framework.Sys
{
  using NUnit.Framework;
  using SitecoreInstaller.Framework.Sys;
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
  }
}