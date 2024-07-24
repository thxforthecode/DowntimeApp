using System.Runtime;

namespace DowntimeAppLibrary.Models;

public class ReportModel
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]

   public string Id { get; set; }

   public string Issue { get; set; }

   public string Solution { get; set; }
   public int DowntimeAmount { get; set; }
   public MachineModel Machine { get; set; }

   public BasicUserModel Author { get; set; }
   public DateTime WhenCreated { get; set; } = DateTime.UtcNow;

   //
   public HashSet<string> UserSaves { get; set; } = new();

   //status is "ongoing" or "resolved" defaults to resolved

   public bool Status { get; set; } = false;

   public bool Archived { get; set; } = false;







}

