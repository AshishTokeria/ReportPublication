using AspNetCore.BuildingBlocks.Database;
using AspNetCore.BuildingBlocks.Database.EF;
using AspNetCore.BuildingBlocks.HealthChecks;
using AspNetCore.BuildingBlocks.Mvc;
using FVA.IPV.ReportPublication.Data;
using FVA.IPV.ReportPublication.Data.Context;
using FVA.IPV.ReportPublication.Model.Configuration;
using FVA.IPV.ReportPublication.WebApi.Extensions;
using MediatR;
using System.Reflection;
using System.Text.Json.Serialization;

namespace FVA.IPV.ReportPublication.WebApi
{
    public class Startup
    {
        IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public async void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(opt =>
            opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            var appConfiguration = new DefaultAppConfiguration();
            Configuration.GetSection("AppConfiguration").Bind(appConfiguration);
            services.AddSingleton<IAppConfiguration>(appConfiguration);

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddSericeConfiguration(Configuration);

            services.AddScoped<IConnectionStringProvider, ConnectionStringProvider>();
            services.AddAndConfigureCreateDbContext<CreateDbContext>();
            services.AddScoped<IReportSettingsDal, ReportSettingsDal>();

            services.AddHealthChecks();
            services.AddSwaggerGen(x => x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Automation process",
                Version = "v1"
            }));

            var sp = services.BuildServiceProvider();
            var settings = sp.GetService<IReportSettingsDal>();

            var env = System.Configuration.ConfigurationManager.AppSettings["Environment"];
            var pathSetting = await settings.GetByName(appConfiguration.LogPathSettingName);
            var logPath = pathSetting.Value.Replace("{$environment}", env) + "\\";
            NLog.LogManager.Configuration.Variables["nasPath"] = logPath;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints => {
                endpoints.MapDefaultControllerRoute();
            });
            string specificInfo = "FVA";
            app.UseReportHealthChecks(specificInfo);
            app.UseSwagger();
            app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "Automation process API v1"); });
        }
    }
}
