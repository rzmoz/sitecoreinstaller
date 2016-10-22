using System;
using System.Collections.Generic;
using SitecoreInstaller.PreflightChecks;

namespace SitecoreInstaller.Databases
{
    public class MongoDbService : DbService
    {
        protected override bool ConnectionEstablished(string instanceName)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<string> AssertInstanceName()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<string> AssertWindowsServiceName()
        {
            throw new NotImplementedException();
        }
    }
}
