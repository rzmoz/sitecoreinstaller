using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;
using DotNet.Basics.Collections;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using MongoDB.Driver;
using NLog;

namespace SitecoreInstaller.Databases
{
    public class DbConnectionStringsFactory
    {
        private readonly MongoDbService _mongoDbService;
        private readonly SqlDbService _sqlDbService;
        private readonly ILogger _logger;

        public DbConnectionStringsFactory(MongoDbService mongoDbService, SqlDbService sqlDbService)
        {
            _mongoDbService = mongoDbService;
            _sqlDbService = sqlDbService;
            _logger = LogManager.GetLogger(nameof(DbConnectionStringsFactory));
        }

        public IEnumerable<DbConnectionString> MergeWithDatabaseFilePairs(string projectName, IEnumerable<DbConnectionString> fromCleanSitecore,
            IEnumerable<SqlDatabaseFilePair> dbFilePairs)
        {
            var updatedEntries = new StringKeyDictionary<DbConnectionString>(DictionaryKeyMode.IgnoreKeyCase);

            foreach (var dbConnectionString in fromCleanSitecore)
                updatedEntries[dbConnectionString.Name.ToLowerInvariant()] = dbConnectionString;

            //update with constrs from files
            foreach (var dbFilePair in dbFilePairs)
                updatedEntries[dbFilePair.Name.ConnectionStringName.ToLowerInvariant()] = 
                    new SqlDbConnectionString(dbFilePair.Name.ConnectionStringName,new SqlConnectionStringBuilder
                    {
                        ConnectTimeout = (int)5.Seconds().TotalMilliseconds,
                        InitialCatalog = dbFilePair.Name.FullName,
                        DataSource = _sqlDbService.InstanceName,
                        UserID = "sa",
                        Password = "1234"
                    });

            //update mongo constrs with project names
            foreach (var mongoDbString in updatedEntries.Where(entry => entry.Value.DbType == DbType.Mongo).ToList())
            {
                var dbName = $"{projectName}_{mongoDbString.Key.Replace(".", "_")}";
                updatedEntries[mongoDbString.Key] = new MongoDbConnectionString(mongoDbString.Key, new MongoUrl($"mongodb://{_mongoDbService.InstanceName}/{dbName }"));
            }

            return updatedEntries.Values;
        }

        public IEnumerable<SqlDatabaseFilePair> Create(string projectName, DirPath databasesDir)
        {
            foreach (var dbFile in databasesDir.EnumerateFiles(FileTypes.SqlMdf.GetAllSearchPattern))
                yield return new SqlDatabaseFilePair(projectName, dbFile);
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
                return new SqlDbConnectionString(name, new SqlConnectionStringBuilder(rawValue));
            }
            catch (Exception)
            {
                //ignore
            }
            try
            {
                return new MongoDbConnectionString(name, new MongoUrlBuilder(rawValue).ToMongoUrl());
            }
            catch (Exception)
            {
                //ignore
            }
            return new UnknownDbConnectionString(name, rawValue);
        }
    }
}
