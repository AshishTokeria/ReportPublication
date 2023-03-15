using System;

namespace FVA.IPV.ReportPublication.Transport.Dto
{
    public class Report
    {
        public DateTime AsOfDate { get; set; }
        public string? Site { get; set; }
        public string? Label { get; set; }
        public int RowCount { get; set; } = 0;
    }
}