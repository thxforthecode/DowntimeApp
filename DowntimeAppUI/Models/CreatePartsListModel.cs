namespace DowntimeAppUI.Models;

public class CreatePartsListModel
{
   public bool isIncluded { get; set; } = false;

   public string PartId { get; set; }

   public string Name { get; set; } 

   public string SerialNumber { get; set; }

   public CreatePartsListModel(BasicPartModel part)
   {
      PartId = part.PartId;
      Name = part.Name;
      SerialNumber = part.SerialNumber;
   }
}
