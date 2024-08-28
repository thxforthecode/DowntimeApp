
namespace DowntimeAppLibrary.DataAccess
{
   public interface IPartData
   {
      Task CreatePart(PartModel part);
      Task<List<PartModel>> GetAllParts();
      Task<PartModel> GetPart(string partId);
   }
}