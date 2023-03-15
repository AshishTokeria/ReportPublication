using System.ComponentModel.DataAnnotations.Schema;

namespace FVA.IPV.ReportPublication.Model.Data
{
    [Table("FVA_IPV_REPORT_HEADER")]
    public class ReportHeader
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("CREATED_ON")]
        public DateTime CreatedOn { get; set; }

        [Column("CREATED_BY")]
        public DateTime CreatedBy { get; set; }

        [Column("SITE_ID")]
        public int SiteId { get; set; }

        [Column("AS_OF_DATE")]
        public DateTime AsOfDate { get; set; }

        [Column("REPORT_TYPE")]
        public string? ReportType { get; set; }
        public IEnumerable<ReportOutputModel> OutputModels { get; set; }
    }
}
