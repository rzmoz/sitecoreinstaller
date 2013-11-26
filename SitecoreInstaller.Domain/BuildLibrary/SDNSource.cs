using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ServiceStack.ServiceClient.Web;
using ServiceStack.Text;
using SitecoreInstaller.Framework.Diagnostics;
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
      _buidLibraryList = new BuildLibraryList();
      var tempFilePath = string.Format(_tempListfileFormat, Path.GetTempPath());
      TempFile = new FileInfo(tempFilePath);
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
      return null;
    }

    public IEnumerable<BuildLibraryResource> Get(IEnumerable<SourceEntry> sourceEntries, SourceType sourceType)
    {
      return from sourceEntry in sourceEntries select Get(sourceEntry, sourceType);
    }

    public void Update()
    {
      var baseUrl = string.Format(_urlFormat, Parameters);
      var client = new JsonServiceClient(baseUrl);
      var response = client.Get<BuildLibraryResponse>("/list");

      lock (_fileLock)
      {
        TempFile.Refresh();
        if (TempFile.Exists)
          TempFile.Delete();
        File.WriteAllText(TempFile.FullName, response.Content);
      }

      UpdateInMemoryList();
    }

    public bool Contains(string name, SourceType sourceType)
    {
      return GetList(sourceType).Any(entry => entry == name);
    }

    public BuildLibraryFile Add(string file, SourceType sourceType) { throw new NotImplementedException(); }
    public void Add(BuildLibraryFile buildLibraryFile, SourceType sourceType) { throw new NotImplementedException(); }
    public void Delete(SourceEntry sourceEntry, SourceType sourceType) { throw new NotImplementedException(); }
    public void Delete(IEnumerable<SourceEntry> keys, SourceType sourceType) { throw new NotImplementedException(); }

    private static FileInfo TempFile { get; set; }

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
      TempFile.Refresh();
      if (!TempFile.Exists)
        return;
      lock (_fileLock)
      {
        try
        {
          string listContent = File.ReadAllText(TempFile.FullName);

          _buidLibraryList = listContent.FromJson<BuildLibraryList>();
          _buidLibraryList.CleanEntries(CleanEntriesForDisplay);
        }
        catch (IOException e)
        {
          Log.This.Error(e.ToString());
        }
      }
    }
  }
}
