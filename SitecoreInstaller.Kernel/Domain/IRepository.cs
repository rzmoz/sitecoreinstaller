using System.Collections.Generic;
using System.IO;

namespace SitecoreInstaller.Domain
{
    public interface IRepository<out T> where T : IResource
    {
        //command
        bool Delete(string name);
        bool Insert(string name, Stream resource, bool throwExceptionIfNotExists = false);

        //query
        IEnumerable<T> GetAll();
        T Get(string name);
        bool Exists(string name);
    }
}
