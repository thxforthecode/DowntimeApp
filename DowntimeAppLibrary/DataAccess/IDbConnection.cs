using MongoDB.Driver;

namespace DowntimeAppLibrary.DataAccess
{
   public interface IDbConnection
   {
      MongoClient Client { get; }
      string DbName { get; }
      IMongoCollection<ReportModel> ReportCollection { get; }
      string ReportCollectionName { get; }
      IMongoCollection<UserModel> UserCollection { get; }
      string UserCollectionName { get; }
   }
}