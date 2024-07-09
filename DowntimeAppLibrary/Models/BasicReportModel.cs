using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DowntimeAppLibrary.Models;
//this model allows userModel.authoredreports/savedreports to link to the full report
// without duplicating all of the data in the report 
public class BasicReportModel
{
   [BsonRepresentation(BsonType.ObjectId)]
   public string Id { get; set; }
   public string Issue { get; set; }

   public BasicReportModel()
   {
      
   }

   public BasicReportModel(ReportModel report)
   {
      Id = report.Id;
      Issue = report.Issue;
      
   }
}
