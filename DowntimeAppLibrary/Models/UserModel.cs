

namespace DowntimeAppLibrary.Models;

public class UserModel
{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]

   public string Id { get; set; }

   public string ObjectIdentifier { get; set; }
   public string FirstName { get; set; }
   public string LastName { get; set; }
   public string Email { get; set; }
   public List<BasicReportModel> AuthoredReports { get; set; } = new();
   public List<BasicReportModel> SavedReports { get; set; } = new();

}
