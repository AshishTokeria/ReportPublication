using FVA.IPV.ReportPublication.WebApi;
using NLog.Web;
using AspNetCore.BuildingBlocks.AppConfig;

public class Program
{
    public static void Main(string[] args)
    {
        var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        try
        {
            logger.Debug("init main");
            CreateHostBuilder(args).Build().Run();

        }
        catch (Exception ex)
        {
            logger.Error(ex, "Stopped program because of exception");
            throw;
        }
        finally
        {
            NLog.LogManager.Shutdown();
        }
    }

    public static IWebHostBuilder CreateHostBuilder(string[] args) =>
        GetWebHostBuilder(args)
        .AddAppConfigWithAppSettings()
        .UseStartup<Startup>();

    public static IWebHostBuilder GetWebHostBuilder(string[] args)
    {
        return new WebHostBuilder()
            .UseKestrel()
            .UseIIS()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((context, builder) =>
            {
                var environment = context.HostingEnvironment;

                builder
                .AddJsonFile("appretting.json", true, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true);

                builder.AddEnvironmentVariables();

                if(args != null)
                {
                    builder.AddCommandLine(args);
                }
            })
            .UseIISIntegration()
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddDebug();
                logging.SetMinimumLevel(LogLevel.Debug);
            }).UseNLog();

    }
}