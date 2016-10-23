using System;
using System.Collections.Generic;
using System.Threading;
using DotNet.Basics.Sys;
using MongoDB.Driver;

namespace SitecoreInstaller.Databases
{
    public class MongoDbService : DbService
    {
        protected override bool ConnectionEstablished(string instanceName)
        {
            try
            {
                var client = new MongoClient(new MongoUrl($"mongodb://{instanceName}/"));
                client.ListDatabases(new CancellationTokenSource(1.Seconds()).Token);
                return true;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
        }

        protected override IEnumerable<string> GetWindowsServiceNameCandidates()
        {
            yield return "mongoDB";
        }

        protected override IEnumerable<string> GetInstanceNameCandidates()
        {
            yield return "localhost:27017";
        }
    }
}
