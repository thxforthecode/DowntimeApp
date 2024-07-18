using Microsoft.Extensions.Caching.Memory;

namespace DowntimeAppLibrary.DataAccess;

public class MongoReportData : IReportData
{
   private readonly IDbConnection _db;
   private readonly IUserData _userData;
   private readonly IMemoryCache _cache;
   private readonly IMongoCollection<ReportModel> _reports;
   private const string CacheName = "ReportData";

   public MongoReportData(IDbConnection db, IUserData userData, IMemoryCache cache)
   {
      _db = db;
      _userData = userData;
      _cache = cache;
      _reports = db.ReportCollection;
   }

   public async Task<List<ReportModel>> GetAllReports()
   {
      var output = _cache.Get<List<ReportModel>>(CacheName);
      if (output == null)
      {
         var results = await _reports.FindAsync(s => s.Archived == false);
         output = results.ToList();

         _cache.Set(CacheName, output, TimeSpan.FromMinutes(1));
      }
      return output;

   }

   public async Task<List<ReportModel>> GetResolvedReports()
   {
      var output = await GetAllReports();
      return output.Where(x => x.Status).ToList();
   }

   public async Task<List<ReportModel>> GetOngoingReports()
   {
      var output = await GetAllReports();
      return output.Where(x => x.Status == false).ToList();
   }

   public async Task<List<ReportModel>> GetReportsByMachine(string machineId)
   {

      //check this one. 
      var output = await GetAllReports();
      return output.Where(x => x.Machine == machineId).ToList();
   }
   public async Task<ReportModel> GetReport(string id)
   {
      var results = await _reports.FindAsync(s => s.Id == id);
      return results.FirstOrDefault();
   }

   public async Task UpdateReport(ReportModel report)
   {
      await _reports.ReplaceOneAsync(s => s.Id == report.Id, report);
      _cache.Remove(CacheName);
   }

   public async Task UserSaveReport(string reportId, string userId)
   {
      var client = _db.Client;

      using var session = await client.StartSessionAsync();

      session.StartTransaction();

      try
      {
         var db = client.GetDatabase(_db.DbName);
         var reportsInTransaction = db.GetCollection<ReportModel>(_db.ReportCollectionName);
         var report = (await reportsInTransaction.FindAsync(r => r.Id == reportId)).First();
         //adds the user to the list of users who have saved this report
         bool isSaved = report.UserSaves.Add(userId);
         //save and unsave report
         if (isSaved == false)
         {
            report.UserSaves.Remove(userId);
         }

         await reportsInTransaction.ReplaceOneAsync(s => s.Id == report.Id, report);

         var usersInTransaction = db.GetCollection<UserModel>(_db.UserCollectionName);
         var user = await _userData.GetUser(userId);
         //adds the report to the user's saved reports list
         if (isSaved)
         {
            user.SavedReports.Add(new BasicReportModel(report));
         }
         else
         {
            var reportToRemove = user.SavedReports.Where(r => r.Id == report.Id).First();
            user.SavedReports.Remove(reportToRemove);
         }
         //update the user
         await usersInTransaction.ReplaceOneAsync(u => u.Id == user.Id, user);

         await session.CommitTransactionAsync();

         //clear the cache
         _cache.Remove(CacheName);

      }
      catch
      {
         await session.AbortTransactionAsync();
         throw;
         //log error

      }
   }


   public async Task CreateReport(ReportModel report)
   {
      var client = _db.Client;
      using var session = await client.StartSessionAsync();
      session.StartTransaction();
      try
      {
         var db = client.GetDatabase(_db.DbName);
         var reportsInTransaction = db.GetCollection<ReportModel>(_db.ReportCollectionName);
         await reportsInTransaction.InsertOneAsync(report);

         var usersInTransaction = db.GetCollection<UserModel>(_db.UserCollectionName);
         var user = await _userData.GetUser(report.Author.Id);
         user.AuthoredReports.Add(new BasicReportModel(report));
         await usersInTransaction.ReplaceOneAsync(u => u.Id == user.Id, user);

         await session.CommitTransactionAsync();
         //clear the cache. this is so that they can see the new report. 
         //this may be modified here if i want to do senitment analysis on the new report or something for future features.
         _cache.Remove(CacheName);
      }
      catch
      {
         await session.AbortTransactionAsync();
         throw;
         //log error
      }
   }
}
