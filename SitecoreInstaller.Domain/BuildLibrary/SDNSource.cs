using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;
using Sitecore.Tasks;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.IO;
using SitecoreInstaller.Framework.Web;
using SitecoreInstaller.Services.ServiceModel;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class SdnSource : ISource
    {
        private static readonly object _fileLock = new object();
        private BuildLibraryList _buidLibraryList;

        private const string _urlFormat = @"http://{0}";
        private const string _tempListfileFormat = @"{0}\sitecoreinstaller.sdn.list.tmp";

        public SdnSource(string name)
        {
            Name = name ?? GetType().Name + Guid.NewGuid();
            var tempFilePath = string.Format(_tempListfileFormat, Path.GetTempPath());
            TempListFile = new FileInfo(tempFilePath);
        }

        public event EventHandler<EventArgs> Updating;
        public event EventHandler<EventArgs> Updated;

        public bool Enabled { get; set; }
        public string Name { get; private set; }
        public string Parameters { get; set; }

        public IEnumerable<SourceEntry> List(SourceType sourceType)
        {
            return GetList(sourceType).Select(entry => new SourceEntry(entry, Name));
        }

        public BuildLibraryResource Get(SourceEntry sourceEntry, SourceType sourceType)
        {
            var resource = sourceType.ToString();
            if (sourceType != SourceType.Sitecore)
                resource += "s";

            var url = string.Format("/{0}/{1}", resource, sourceEntry);
            var response = CallRest(url);

            if (response.Content.Trim().Length == 0)
                return new VoidBuildLibraryResource();

            var targetFile = new FileInfo(Path.Combine(Path.GetTempPath(), sourceEntry.Key + ".zip"));

            Curl.Download(response.ResourceUri, targetFile);

            return new BuildLibraryFile(targetFile, BuildLibraryFileCopyOptions.DeleteAfterCopy);
        }

        private BuildLibraryResponse CallRest(string url)
        {
            var baseUrl = string.Format(_urlFormat, Parameters);
            var client = new JsonServiceClient(baseUrl);
            try
            {
                return client.Get<BuildLibraryResponse>(url);
            }
            catch (WebException e)
            {
                Log.ToApp.Error(e.ToString());
                return new BuildLibraryResponse();
            }
        }

        public IEnumerable<BuildLibraryResource> Get(IEnumerable<SourceEntry> sourceEntries, SourceType sourceType)
        {
            return from sourceEntry in sourceEntries select Get(sourceEntry, sourceType);
        }

        public void Update()
        {
            TempListFile.Refresh();
            DeleteTempFileIfCorrupted();
            if (!TempListFile.Exists)
                GetListFromRestService();
            UpdateInMemoryList();
        }

        private void DeleteTempFileIfCorrupted()
        {
            lock (_fileLock)
            {
                var content = File.ReadAllText(TempListFile.FullName);
                if (content.Trim().Length == 0)
                    TempListFile.Delete();
            }
        }

        private void GetListFromRestService()
        {
            var response = CallRest("/list");

            //we don't write anything is the response is empty
            if (response.Content.Trim().Length == 0)
                return;

            lock (_fileLock)
            {
                TempListFile.TryDelete();
                File.WriteAllText(TempListFile.FullName, response.Content);
            }
        }

        public bool Contains(string name, SourceType sourceType)
        {
            return GetList(sourceType).Any(entry => entry == name);
        }

        public BuildLibraryFile Add(string file, SourceType sourceType) { throw new NotImplementedException(); }
        public void Add(BuildLibraryFile buildLibraryFile, SourceType sourceType) { throw new NotImplementedException(); }
        public void Delete(SourceEntry sourceEntry, SourceType sourceType) { throw new NotImplementedException(); }
        public void Delete(IEnumerable<SourceEntry> keys, SourceType sourceType) { throw new NotImplementedException(); }

        private static FileInfo TempListFile { get; set; }

        private IEnumerable<string> GetList(SourceType sourceType, bool forceUpdate = false)
        {
            if (forceUpdate || _buidLibraryList == null)
            {
                UpdateInMemoryList();
            }

            if (_buidLibraryList == null)
                return Enumerable.Empty<string>();

            switch (sourceType)
            {
                case SourceType.License:
                    return _buidLibraryList.Licenses;
                case SourceType.Module:
                    return _buidLibraryList.Modules;
                case SourceType.Sitecore:
                    return _buidLibraryList.Sitecore;
                default:
                    throw new ArgumentException("sourceType not support: " + sourceType);
            }
        }

        private IEnumerable<string> CleanEntriesForDisplay(IEnumerable<string> entries)
        {
            return entries.Select(HttpUtility.UrlDecode);
        }

        private void UpdateInMemoryList()
        {
            TempListFile.Refresh();
            if (!TempListFile.Exists)
                GetListFromRestService();

            lock (_fileLock)
            {
                try
                {
                    string listContent = File.ReadAllText(TempListFile.FullName);

                    _buidLibraryList = listContent.FromJson<BuildLibraryList>();
                    _buidLibraryList.CleanEntries(CleanEntriesForDisplay);
                }
                catch (IOException e)
                {
                    Log.ToApp.Error(e.ToString());
                }
            }
            //fire and forget the download of an updated file so it's downloaded for next usage
            System.Threading.Tasks.Task.Factory.StartNew(GetListFromRestService);
        }
    }
}

