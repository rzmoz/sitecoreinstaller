using CSharp.Basics.IO;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.Configuration;
using SitecoreInstaller.Framework.Web;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class SourceManifestRepository : IEnumerable<SourceManifest>
    {
        private List<SourceManifest> _manifests;
        private static readonly object _manifestsLock = new object();
        private static readonly object _fileLock = new object();
        private const string _tempExternalManifestsFormat = @"{0}\sitecoreinstaller.external.manifest.{1}.tmp";
        public event EventHandler ManifestsUpdated;

        public SourceManifestRepository(FileInfo sourceFile)
        {
            _manifests = new List<SourceManifest>();
            SourceFile = sourceFile;
        }

        public void UpdateLocal()
        {
            var localManifests = LoadManifests(SourceFile, GetLocalManifests).ToList();
            AddManifests(localManifests);
        }

        public void UpdateExternal()
        {
            var externalManifests = GetExternalManifests(SourceFile);
            AddManifests(externalManifests);
        }

        private void AddManifests(IEnumerable<SourceManifest> manifests)
        {
            if (manifests == null)
                return;

            lock (_manifestsLock)
            {
                _manifests = _manifests.Concat(manifests.Distinct()).ToList();
            }
            if (ManifestsUpdated != null)
                ManifestsUpdated(this, EventArgs.Empty);
        }

        private IEnumerable<SourceManifest> LoadManifests(FileInfo sourceFile, Func<ConfigFile<SourceManifestConfig>, IEnumerable<SourceManifest>> getManifestsFunc)
        {
            var manifests = new List<SourceManifest>();
            var sources = new ConfigFile<SourceManifestConfig>(sourceFile);
            sources.Load();
            manifests.AddRange(getManifestsFunc(sources));
            return manifests.Distinct();
        }

        private IEnumerable<SourceManifest> GetLocalManifests(ConfigFile<SourceManifestConfig> sources)
        {
            return sources.Properties.Manifests;
        }

        private IEnumerable<SourceManifest> GetExternalManifests(FileInfo sources)
        {
            return GetExternalManifests(new ConfigFile<SourceManifestConfig>(sources));
        }
        private IEnumerable<SourceManifest> GetExternalManifests(ConfigFile<SourceManifestConfig> sources)
        {
            var files = new List<FileInfo>();
            foreach (var source in sources.Properties.ExternalSources)
            {
                switch (source.Type)
                {
                    case ExternalSourceType.HttpGet:
                        var file = new FileInfo(string.Format(_tempExternalManifestsFormat, Path.GetTempPath(), source.GetHashCode()));
                        if (file.Exists)
                            lock (_fileLock)
                                files.Add(file);
                        break;
                    default:
                        throw new NotSupportedException("source type is not supported:" + source.Type);
                }
                //always download file to have an updated list ready for next usage
                var externalSource = source;
                Task.Factory.StartNew(() => DownloadExternalSourceFile(externalSource));
            }

            var manifests = new List<SourceManifest>();
            foreach (var fileInfo in files)
            {
                manifests.AddRange(LoadManifests(fileInfo, GetLocalManifests));
            }
            return manifests.Distinct();
        }

        private void DownloadExternalSourceFile(ExternalSource source)
        {
            var sourceFile = new FileInfo(string.Format(_tempExternalManifestsFormat, Path.GetTempPath(), source.GetHashCode()));
            lock (_fileLock)
            {
                try
                {
                    TheWww.DownloadFile(source.Uri, sourceFile);
                    var manifests = LoadManifests(sourceFile, GetLocalManifests);
                    AddManifests(manifests);
                }
                catch (Exception)
                {
                    sourceFile.TryDelete();
                }
            }
        }

        public FileInfo SourceFile { get; private set; }

        public IEnumerable<SourceManifest> Enabled
        {
            get { return _manifests.Where(x => x.Enabled); }
        }

        public SourceManifest Get(string name)
        {
            return _manifests.FirstOrDefault(manifest => manifest.Name == name);
        }

        public void Add(SourceManifest sourceManifest)
        {
            _manifests.Add(sourceManifest);
        }

        public IEnumerator<SourceManifest> GetEnumerator()
        {
            return _manifests.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
