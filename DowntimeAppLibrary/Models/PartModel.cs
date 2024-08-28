

namespace DowntimeAppLibrary.Models;
public class PartModel
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string PartId { get; set; }
   public string SerialNumber { get; set; }

   public string Name { get; set; }

   public string Supplier { get; set; }

   public string? Description { get; set; }

   public List<BasicMachineModel> Machines { get; set; }
}
