namespace DowntimeAppUI;
//created this to handle dependency injection here instead of inside of Program.cs
public static class RegisterServices
{
   public static void ConfigureServices(this WebApplicationBuilder builder)
   {
      // Add services to the container.
      builder.Services.AddRazorPages();
      builder.Services.AddServerSideBlazor();
      builder.Services.AddMemoryCache();

      builder.Services.AddSingleton<IDbConnection, DbConnection>();
      builder.Services.AddSingleton<IMachineData, MongoMachineData>();
      builder.Services.AddSingleton<IUserData, MongoUserData>();
      builder.Services.AddSingleton<IReportData, MongoReportData>();

   }
}
