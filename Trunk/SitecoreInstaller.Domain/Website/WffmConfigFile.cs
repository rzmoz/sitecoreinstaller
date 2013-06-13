namespace SitecoreInstaller.Domain.Website
{
  using System;
  using System.IO;
  using System.Linq;
  using System.Xml.Linq;

  public class WffmConfigFile
  {
    private readonly XDocument _formsConfigFile;

    public WffmConfigFile(FileInfo formsConfigfile)
      : this(XDocument.Load(formsConfigfile.FullName))
    {
      if (formsConfigfile == null) { throw new ArgumentNullException("formsConfigfile"); }
    }

    public WffmConfigFile(XDocument formsConfigFile)
    {
      _formsConfigFile = formsConfigFile;

      ResolveDataProviderType();
    }

    private void ResolveDataProviderType()
    {
      var dataProvider = _formsConfigFile.Descendants("formsDataProvider").Single();
      if (dataProvider == null)
      {
        DataProviderType = DataProviderType.Unknown;
        return;
      }

      var type = dataProvider.Attribute("type").Value;

      if (type.Equals("Sitecore.Forms.Data.DataProviders.WFMDataProvider,Sitecore.Forms.Core"))
        DataProviderType = DataProviderType.Sql;
      else if (type.Equals("Sitecore.Forms.Data.DataProviders.Oracle.OracleWFMDataProvider,Sitecore.Forms.Oracle"))
        DataProviderType = DataProviderType.Oracle;
      else if (type.Equals("Sitecore.Forms.Data.DataProviders.SQLite.SQLiteWFMDataProvider,Sitecore.Forms.Core"))
        DataProviderType = DataProviderType.SQLite;
      else
        DataProviderType = DataProviderType.Unknown;
    }

    public DataProviderType DataProviderType { get; private set; }
  }
}
