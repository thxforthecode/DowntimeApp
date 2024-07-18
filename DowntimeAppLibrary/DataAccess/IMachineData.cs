
namespace DowntimeAppLibrary.DataAccess
{
   public interface IMachineData
   {
      Task CreateMachines(MachineModel machine);
      Task<List<MachineModel>> GetAllMachines();
   }
}