

namespace DowntimeAppLibrary.Models;

public class BasicPartModel
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]
   public string PartId { get; set; }

   public string Name { get; set; }

   public string SerialNumber { get; set; }
   public BasicPartModel(PartModel part)
   {
      PartId = part.PartId;
      Name = part.Name;
      SerialNumber = part.SerialNumber;
   }
}
