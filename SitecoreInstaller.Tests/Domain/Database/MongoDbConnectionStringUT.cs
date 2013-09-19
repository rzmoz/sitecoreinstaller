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
    public class MongoDbConnectionStringUT
    {
        [Test]
        [TestCase(MockConnectionStrings.Mongo.Default)]
        [TestCase(MockConnectionStrings.Mongo.WithUsernameAndPassword)]
        public void IsValid_CheckConnectionStringFormat_ValueIsValid(string connectionString)
        {
            var conStr = new MongoConnectionString { Value = connectionString };

            conStr.IsValid().Should().BeTrue();
        }
        [Test]
        [TestCase(MockConnectionStrings.MsSql.StandardSecurtiy)]
        [TestCase(MockConnectionStrings.MsSql.TrustedConnection)]
        [TestCase(MockConnectionStrings.MsSql.ConnectionToASQLServerInstance)]
        public void IsValid_CheckConnectionStringFormat_ValueIsNotValid(string connectionString)
        {
            var conStr = new MongoConnectionString { Value = connectionString };

            conStr.IsValid().Should().BeFalse();
        }
    }
}
