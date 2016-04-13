using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SitecoreInstaller.Domain.Database;

namespace SitecoreInstaller.Tests.Domain.Database
{
    [TestFixture]
    public class MsSqlConnectionStringUT
    {
        [Test]
        [TestCase("user id=user;password=password;Data Source=(server);Database=Sitecore_Core")]
        [TestCase(MockConnectionStrings.MsSql.StandardSecurtiy)]
        [TestCase(MockConnectionStrings.MsSql.TrustedConnection)]
        [TestCase(MockConnectionStrings.MsSql.ConnectionToASQLServerInstance)]
        public void IsValid_CheckConnectionStringFormat_ValueIsValid(string connectionString)
        {
            var conStr = new MsSqlConnectionString { Value = connectionString };

            conStr.IsValid().Should().BeTrue();
        }
    }
}
