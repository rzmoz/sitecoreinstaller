using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using MongoDB.Driver;
using NLog;

namespace SitecoreInstaller.Databases
{
    public class DbConnectionStringsFactory
    {
        private readonly ILogger _logger;

        public DbConnectionStringsFactory()
        {
            _logger = LogManager.GetLogger(nameof(DbConnectionStringsFactory));
        }

        public IEnumerable<DbConnectionString> Create(DirPath databasesDir)
        {
            foreach (var dbFile in databasesDir.EnumerateFiles(FileTypes.SqlMdf.GetAllSearchPattern))
            {
                var name = dbFile.NameWithoutExtension.RemovePrefix("sitecore.");
                yield return new SqlDbTrustedConnectionString(name, ".");
            }
        }

        public IEnumerable<DbConnectionString> Create(FilePath connectionStringsConfig)
        {
            if (connectionStringsConfig == null) throw new ArgumentNullException(nameof(connectionStringsConfig));
            if (connectionStringsConfig.Exists())
            {
                var connectionStrings = XDocument.Load(connectionStringsConfig.FullName);
                var entryElements = connectionStrings.Descendants("add");
                foreach (var entryElement in entryElements)
                {
                    var name = entryElement.Attribute("name").Value;
                    var connectionString = entryElement.Attribute("connectionString").Value;
                    yield return Create(name, connectionString);
                }
            }
            else
                _logger.Error($"ConnectionsStrings file not found at {connectionStringsConfig.FullName}");
        }

        private DbConnectionString Create(string name, string rawValue)
        {
            try
            {
                return new SqlDbConnectionString(name.ToLower(), new SqlConnectionStringBuilder(rawValue));
            }
            catch (Exception)
            {
                //ignore
            }
            try
            {
                return new MongoDbConnectionString(name.ToLower(), new MongoUrlBuilder(rawValue).ToMongoUrl());
            }
            catch (Exception)
            {
                //ignore
            }
            return new UnknownDbConnectionString(name.ToLower(), rawValue);
        }
    }
}
