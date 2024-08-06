namespace DowntimeAppLibrary.Models;

public class MachineModel
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]

   public string MachineId { get; set; }
   public string MachineName { get; set; }
   public string MachineDept { get; set; }

   public string MachineDescription { get; set; }
}
