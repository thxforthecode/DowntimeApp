using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;

namespace DowntimeAppLibrary.DataAccess;

public class MongoMachineData : IMachineData
{
   private readonly IMongoCollection<MachineModel> _machines;
   private readonly IMemoryCache _cache;
   private const string cacheName = "MachineData";
   public MongoMachineData(IDbConnection db, IMemoryCache cache)
   {
      _cache = cache;
      _machines = db.MachineCollection;
   }

   public async Task<List<MachineModel>> GetAllMachines()
   {
      //may need to change this to be able to add machines and then immediately add a report (launch only really)
      var output = _cache.Get<List<MachineModel>>(cacheName);
      if (output == null)
      {
         var results = await _machines.FindAsync(_ => true);
         output = results.ToList();

         _cache.Set(cacheName, output, TimeSpan.FromDays(1));
      }

      return output;

   }

   public Task CreateMachines(MachineModel machine)
   {
      return _machines.InsertOneAsync(machine);
   }


}
