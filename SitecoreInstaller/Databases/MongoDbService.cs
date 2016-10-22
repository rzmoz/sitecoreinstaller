using System.Collections.Generic;

namespace SitecoreInstaller.Databases
{
    public class MongoDbService : DbService
    {
        protected override bool ConnectionEstablished(string instanceName)
        {
            return false;
        }

        protected override IEnumerable<string> GetWindowsServiceNameCandidates()
        {
            yield return "mongoDB";
        }

        protected override IEnumerable<string> GetInstanceNameCandidates()
        {
            yield return "mongo";
        }
    }
}
