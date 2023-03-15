using MediatR;

namespace FVA.IPV.ReportPublication.Provider.Request
{
    public class PublishReportRequest : IRequest<bool>
    {
        public DateTime AsOfDate { get; set; }
        public string Site { get; set; }
        public string Label { get; set; }
        public int RowCount { get; set; } = 0;

        public PublishReportRequest(DateTime asOfDate, string site, string label, int rowCount)
        {
            AsOfDate = asOfDate;
            Site = site;
            Label = label;
            RowCount = rowCount;
        }
    }
}
