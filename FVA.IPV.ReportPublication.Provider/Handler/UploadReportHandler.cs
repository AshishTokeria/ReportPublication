using FVA.IPV.ReportPublication.Data;
using FVA.IPV.ReportPublication.Model.Data;
using FVA.IPV.ReportPublication.Provider.Provider;
using FVA.IPV.ReportPublication.Provider.Request;
using FVA.IPV.ReportPublication.Service;
using MediatR;

namespace FVA.IPV.ReportPublication.Provider.Handler
{
    public class UploadReportHandler : IRequestHandler<UploadReportRequest, int>
    {
        private readonly IReportOutputProvider _reportOutputProvider;
        private readonly ICsvStreamProvider _csvStreamProvider;
        private readonly IUploadService _uploadService;
        private readonly IReportSettingsDal _reportSettingsDal;

        public UploadReportHandler(IReportOutputProvider reportOutputProvider, 
            ICsvStreamProvider csvStreamProvider, 
            IUploadService uploadService,
            IReportSettingsDal reportSettingsDal)
        {
            _reportOutputProvider = reportOutputProvider;
            _csvStreamProvider = csvStreamProvider;
            _uploadService = uploadService;
            _reportSettingsDal = reportSettingsDal;
        }

        public async Task<int> Handle(UploadReportRequest request, CancellationToken cancellationToken)
        {
            return await UploadReportAsync(request);
        }

        private async Task<int> UploadReportAsync(UploadReportRequest request)
        {
            var amsoutput = await _reportOutputProvider.GetReportOutputAsync(request.DTime, request.Site);
            var stream = _csvStreamProvider.GenerateCsvStream(amsoutput);

            string pubKey = "";

            var uploadModel = new UploadModel()
            {
                UploadKey = pubKey,
                Compress = false,
                RowCount = amsoutput.Count(),
                OutPutStream = stream
            };

            return await _uploadService.Upload(uploadModel, request.DTime, request.Site);
        }
    }
}
