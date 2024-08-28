
namespace DowntimeAppLibrary.Models;

public class BasicMachineModel
{
   [BsonRepresentation(BsonType.ObjectId)]
   public string MachineId { get; set; }

   public string MachineName { get; set; }

   public BasicMachineModel(MachineModel mach)
   {
      MachineId = mach.MachineId;
      MachineName = mach.MachineName;
   }
}
