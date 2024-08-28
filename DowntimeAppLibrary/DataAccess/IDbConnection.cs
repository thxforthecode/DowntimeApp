using MongoDB.Driver;

namespace DowntimeAppLibrary.DataAccess
{
   public interface IDbConnection
   {
      MongoClient Client { get; }
      string DbName { get; }

      IMongoCollection<MachineModel> MachineCollection { get; }
      string MachineCollectionName { get; }

      IMongoCollection<ReportModel> ReportCollection { get; }
      string ReportCollectionName { get; }
      IMongoCollection<UserModel> UserCollection { get; }
      string UserCollectionName { get; }
      IMongoCollection<PartModel> PartCollection { get; }
      string PartCollectionName { get; }
   }
}