using System.Collections.Generic;
using System.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public interface ISource : ISourceRepository
    {
        bool Enabled { get; set; }
        string Name { get; }
        string Parameters { get; set; }

        bool Contains(string name, SourceType sourceType);
    }
}
