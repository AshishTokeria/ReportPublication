using FVA.IPV.ReportPublication.Model.Data;
using Microsoft.Extensions.Logging;

namespace FVA.IPV.ReportPublication.Service
{
    public interface IUploadService
    {
        public Task<int> Upload(UploadModel uploadModel, DateTime asOfDate, string site);
    }


    public class UploadService : IUploadService
    {
        private readonly ILogger<UploadService> _logger;

        public UploadService(ILogger<UploadService> logger)
        {
            _logger = logger;
        }
        public async Task<int> Upload(UploadModel uploadModel, DateTime asOfDate, string site)
        {
            _logger.LogInformation($"Report uploaded for AsOfDate {asOfDate}, Rows: {uploadModel.RowCount}, Site: {site}");
            return await Task.FromResult(5);
        }
    }
}