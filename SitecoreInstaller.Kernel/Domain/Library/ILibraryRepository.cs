using System.IO;
using System.Collections.Generic;

namespace SitecoreInstaller.Domain.Library
{
    public interface ILibraryRepository<T> where T : ILibraryResource
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
