

using Amazon.Runtime.Internal.Util;
using Microsoft.Extensions.Caching.Memory;
using System.Reflection.PortableExecutable;

namespace DowntimeAppLibrary.DataAccess;

public class MongoPartData : IPartData
{
   private readonly IMemoryCache _cache;
   private readonly IMongoCollection<PartModel> _parts;
   private const string cacheName = "PartData";

   public MongoPartData(IDbConnection db, IMemoryCache cache)
   {
      _cache = cache;
      _parts = db.PartCollection;
   }

   public async Task<List<PartModel>> GetAllParts()
   {
      //probably wont use this other than for admin removal/editing
      var output = _cache.Get<List<PartModel>>(cacheName);
      if (output == null)
      {
         var results = await _parts.FindAsync(_ => true);
         output = results.ToList();

         _cache.Set(cacheName, output, TimeSpan.FromMinutes(1));
      }
      return output;
   }

   public async Task<PartModel> GetPart(string partId)
   {
      var output = await _parts.FindAsync(p => p.PartId == partId);
      //might actually want to return more than one if its there. not sure what that would look like. 
      return output.FirstOrDefault();
   }

   public Task CreatePart(PartModel part)
   {
      return _parts.InsertOneAsync(part);
   }

}
