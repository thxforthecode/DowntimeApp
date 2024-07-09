﻿

using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DowntimeAppLibrary.DataAccess;

public class DbConnection
{
   private readonly IConfiguration _config;
   private readonly IMongoDatabase _db;
   private string _connectionId = "MongoDB";
   public string DbName { get; private set; }
   public string ReportCollectionName { get; private set; } = "reports";
   public string UserCollectionName { get; private set; } = "users";

   public MongoClient Client { get; private set; }
   public IMongoCollection<ReportModel> ReportCollection { get; private set; }
   public IMongoCollection<UserModel> UserCollection { get; private set; }

   public DbConnection(IConfiguration config)
   {
      _config = config;
      Client = new MongoClient(_config.GetConnectionString(_connectionId));
      DbName = _config["DatabaseName"];
      _db = Client.GetDatabase(DbName);

      ReportCollection = _db.GetCollection<ReportModel>(ReportCollectionName);
      UserCollection = _db.GetCollection<UserModel>(UserCollectionName);
            
   }
   

}