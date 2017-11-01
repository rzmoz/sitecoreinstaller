using System;
using System.Collections.Generic;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library
{
    public class LibraryRepository<T> : DirPath
    {
        public LibraryRepository(string path, params string[] segments) : base(path, segments)
        {
        }
        
        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
