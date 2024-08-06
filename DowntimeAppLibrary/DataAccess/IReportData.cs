
namespace DowntimeAppLibrary.DataAccess
{
   public interface IReportData
   {
      Task CreateReport(ReportModel report);
      Task<List<ReportModel>> GetAllReports();
      Task<List<ReportModel>> GetOngoingReports();
      Task<List<ReportModel>> GetReportsByMachine(string machineId);
      Task<ReportModel> GetReport(string id);
      Task<List<ReportModel>> GetResolvedReports();
      Task UpdateReport(ReportModel report);
      Task UserSaveReport(string reportId, string userId);
      Task<List<ReportModel>> GetAuthoredReports(string userId);
   }
}