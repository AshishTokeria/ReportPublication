using System.ComponentModel.DataAnnotations.Schema;

namespace FVA.IPV.ReportPublication.Model.Configuration
{
    [Table("ReportSettings")]
    public class ReportSettings
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string? Name { get; set; }

        [Column("VALUE")]
        public string? Value { get; set; }
    }
}
