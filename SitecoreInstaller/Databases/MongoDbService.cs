using System;
using System.Collections.Generic;
using System.Threading;
using DotNet.Basics.Sys;
using MongoDB.Driver;

namespace SitecoreInstaller.Databases
{
    public class MongoDbService : DbService
    {
        private BasicSettings _basicSettings;

        public MongoDbService(BasicSettings basicSettings)
        {
            if (basicSettings == null) throw new ArgumentNullException(nameof(basicSettings));
            _basicSettings = basicSettings;
        }

        protected override bool ConnectionEstablished(string instanceName)
        {
            try
            {
                var client = GetClient(instanceName);
                client.ListDatabases(new CancellationTokenSource(1.Seconds()).Token);
                return true;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
        }

        public void DropCollections(IEnumerable<MongoDbConnectionString> mongoDbConnectionStrings)
        {
            var client = GetClient(InstanceName);

            WorkOnConnectionStrings(() => mongoDbConnectionStrings, conStr =>
            {
                client.DropDatabase(conStr.DatabaseName);
            }, "dropping", "dropped");
        }

        protected override IEnumerable<string> GetWindowsServiceNameCandidates()
        {
            yield return _basicSettings.MongoWindowsServiceName;
        }

        protected override IEnumerable<string> GetInstanceNameCandidates()
        {
            yield return _basicSettings.MongoHost;
        }

        protected override void CustomAssert(List<string> issues)
        {
        }

        private MongoClient GetClient(string instanceName) => new MongoClient(new MongoUrl($"mongodb://{instanceName}/"));
    }
}
