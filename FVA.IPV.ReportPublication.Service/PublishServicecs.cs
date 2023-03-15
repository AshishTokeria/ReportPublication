using Microsoft.Extensions.Logging;

namespace FVA.IPV.ReportPublication.Service
{
    public interface IPublishServicecs
    {
        public Task<bool> PublishAsync(DateTime asOfDate, int rowCount, string publishKey, string url, string publishName);
    }

    public class PublishServicecs : IPublishServicecs
    {
        private readonly ILogger<PublishServicecs> _logger;
        private readonly IUploadService _uploadService;

        public PublishServicecs(ILogger<PublishServicecs> logger, IUploadService uploadService)
        {
            _logger = logger;
            _uploadService = uploadService;
        }

        public Task<bool> PublishAsync(DateTime asOfDate, int rowCount, string publishKey, string url, string publishName)
        {
            _logger.LogInformation($"Report published for AsOfDate {asOfDate}, Rows: {rowCount}, PublishKey: {publishKey} and PublishName: {publishName}");
            return Task.FromResult(true);
        }
    }
}
