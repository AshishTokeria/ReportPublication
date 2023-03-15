using FVA.IPV.ReportPublication.Data;
using FVA.IPV.ReportPublication.Model;
using FVA.IPV.ReportPublication.Model.Configuration;
using FVA.IPV.ReportPublication.Provider.Request;
using FVA.IPV.ReportPublication.Service;
using MediatR;

namespace FVA.IPV.ReportPublication.Provider.Handler
{
    public class PublishReportHandler : IRequestHandler<PublishReportRequest, bool>
    {
        private readonly ReportNameSpaceConfiguration _namespaceConfiguration;
        private readonly IPublishServicecs _publishServicecs;
        private readonly IReportSettingsDal _reportSettingsDal;

        public PublishReportHandler(ReportNameSpaceConfiguration namespaceConfiguration, IPublishServicecs publishServicecs, IReportSettingsDal reportSettingsDal)
        {
            _namespaceConfiguration = namespaceConfiguration;
            _publishServicecs = publishServicecs;
            _reportSettingsDal = reportSettingsDal;
        }

        public async Task<bool> Handle(PublishReportRequest reportRequest, CancellationToken token)
        {
            return await PublishTask(new PublishReportRequest(reportRequest.AsOfDate, reportRequest.Site, reportRequest.Label, reportRequest.RowCount), reportRequest.AsOfDate);
        }

        public async Task<bool> PublishTask(PublishReportRequest reportRequest, DateTime asOfDate)
        {
            var report_publish_metadata = await _reportSettingsDal.GetByName(Constants.PUB_METADATA);
            var report_upload_folder = await _reportSettingsDal.GetByName(Constants.UPLOAD_FOLDER);

            var key = $"";
            var url = $"";

            var publisherName = "";
            return await _publishServicecs.PublishAsync(asOfDate, reportRequest.RowCount, key, url, publisherName);
        }
    }
}
