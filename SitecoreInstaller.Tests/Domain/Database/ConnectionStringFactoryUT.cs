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
    public class ConnectionStringFactoryUT
    {
        [Test]
        [TestCase(MockConnectionStrings.Mongo.Default)]
        [TestCase(MockConnectionStrings.Mongo.WithUsernameAndPassword)]
        public void Create_ConStringType_TypeIsMongo(string connectionString)
        {
            var factory = new ConnectionStringFactory();

            var con = factory.Create(connectionString);

            con.GetType().Should().Be<MongoConnectionString>();
        }
        [Test]
        [TestCase(MockConnectionStrings.MsSql.StandardSecurtiy)]
        [TestCase(MockConnectionStrings.MsSql.TrustedConnection)]
        [TestCase(MockConnectionStrings.MsSql.ConnectionToASQLServerInstance)]
        public void Create_ConStringType_TypeIsMsSql(string connectionString)
        {
            var factory = new ConnectionStringFactory();

            var con = factory.Create(connectionString);

            con.GetType().Should().Be<MsSqlConnectionString>();
        }
    }
}
