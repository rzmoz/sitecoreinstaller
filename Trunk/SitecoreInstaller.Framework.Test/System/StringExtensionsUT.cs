using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SitecoreInstaller.Framework.System;

namespace SitecoreInstaller.Test.UT.Framework.System
{
    [TestFixture]
    public class StringExtensionsUT
    {
        [Test]
        [TestCase("ct3translation",1)]
        public void TokenizeWhenCharIsUpper_TokenizeWhenCharIsUpper_StringIsTokenized(string input, int expectedTokens)
        {
            var result = input.TokenizeWhenCharIsUpper();
            Assert.AreEqual(expectedTokens, result.Count());
        }

        [Test]
        public void UrlCombine_PathCombination_PathIsCombinedAndSeperatedBySlash()
        {
            const string root = "root";
            const string expected = "root/part1/part2/part3";
            var result = root.UrlCombine("part1", "part2", "part3");
            
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void UrlCombine_TrickyPathCombination_PathIsCombinedAndSeperatedBySlash()
        {
            const string root = "root.sc.local/";
            const string expected = @"root.sc.local/part1/part2/part3";
            var result = root.UrlCombine(@"//part1\part2///part3");

            Assert.AreEqual(expected, result);
        }
    }
}