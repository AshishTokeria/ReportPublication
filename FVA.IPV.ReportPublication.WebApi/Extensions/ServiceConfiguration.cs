using FVA.IPV.ReportPublication.Data;
using FVA.IPV.ReportPublication.Model.Configuration;
using FVA.IPV.ReportPublication.Provider.Handler;
using FVA.IPV.ReportPublication.Provider.Provider;
using FVA.IPV.ReportPublication.Provider.Request;
using FVA.IPV.ReportPublication.Service;
using MediatR;

namespace FVA.IPV.ReportPublication.WebApi.Extensions
{
    public static class ServiceConfiguration
    {
        public static void AddSericeConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            //var aesConfig = configuration.GetSection("Encryption").Get<EncryptionConfiguration>();
            //var aesEncryption = new AesEncryption(new LoggerFactory(), aesConfig);

            service.AddScoped<IReportOutputModelDal, ReportOutputModelDal>();
            service.AddScoped<IReportHeaderDal, ReportHeaderDal>();
            service.AddScoped<IReportSettingsDal, ReportSettingsDal>();

            service.AddScoped<IReportOutputProvider, ReportOutputProvider>();
            service.AddScoped<ICsvStreamProvider, CsvStreamProvider>();

            service.AddScoped<IPublishServicecs, PublishServicecs>();
            service.AddScoped<IUploadService, UploadService>();

            var namespaceConfig = configuration.GetSection("ReportNameSpaceConfiguration")
                .Get<ReportNameSpaceConfiguration>();

            service.AddScoped<IRequestHandler<UploadReportRequest, int>, UploadReportHandler>();
            service.AddScoped<IRequestHandler<PublishReportRequest, bool>, PublishReportHandler>(p =>
                ActivatorUtilities.CreateInstance<PublishReportHandler>(p, namespaceConfig));
        }
    }
}
