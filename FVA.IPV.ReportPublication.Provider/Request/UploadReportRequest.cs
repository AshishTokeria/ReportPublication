using MediatR;


namespace FVA.IPV.ReportPublication.Provider.Request
{
    public class UploadReportRequest : IRequest<int>
    {
        public DateTime DTime { get; set; }
        public string Site { get; set; }

        public UploadReportRequest(DateTime dTime, string site)
        {
            DTime = dTime;
            Site = site;
        }
    }
}
