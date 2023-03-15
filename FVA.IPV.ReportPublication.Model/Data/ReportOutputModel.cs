using FVA.IPV.ReportPublication.WebUtil;
using System.ComponentModel.DataAnnotations.Schema;

namespace FVA.IPV.ReportPublication.Model.Data
{
    [Table("FVA_IPV_REPORT_OUTPUT")]
    public class ReportOutputModel : DataModel
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("HEADER_ID")]
        public int HeaderId { get; set; }

        [Column("ASOFDATE")]
        [GridColumnAttribue(ColumnOrder = 0, ViewName = Constants.REPORT, Caption ="As_Of_Date", Visible =true)]
        public DateTime AsOfDate { get; set; }

        [Column("BOOK")]
        [GridColumnAttribue(ColumnOrder = 1, ViewName = Constants.REPORT, Caption = "Book", Visible = true)]
        public string? Book { get; set; }

        [Column("PORTFOLIO")]
        [GridColumnAttribue(ColumnOrder = 2, ViewName = Constants.REPORT, Caption = "Portfolio", Visible = true)]
        public string? Portfolio { get; set; }

        [Column("CURRENCY")]
        [GridColumnAttribue(ColumnOrder = 3, ViewName = Constants.REPORT, Caption = "Currency", Visible = true)]
        public string? Currency { get; set; }

        [Column("ISIN")]
        [GridColumnAttribue(ColumnOrder = 4, ViewName = Constants.REPORT, Caption = "Isin", Visible = true)]
        public string? Isin { get; set; }

        [Column("PRICE")]
        [GridColumnAttribue(ColumnOrder = 5, ViewName = Constants.REPORT, Caption = "Price", Visible = true)]
        public decimal? Price { get; set; }

        [Column("AMORTIZATION_COST")]
        [GridColumnAttribue(ColumnOrder = 6, ViewName = Constants.REPORT, Caption = "Amortization_Cost", Visible = true)]
        public decimal? AmortizationCost { get; set; }

        [Column("DISCOUNT_AT_INCEPTION")]
        [GridColumnAttribue(ColumnOrder = 7, ViewName = Constants.REPORT, Caption = "Discount_At_Inception", Visible = true)]
        public decimal? DiscountAtInception { get; set; }

        [Column("REVISED_DISCOUNT")]
        [GridColumnAttribue(ColumnOrder = 8, ViewName = Constants.REPORT, Caption = "Revised_Discount", Visible = true)]
        public decimal? RevisedDiscount { get; set; }

        [Column("REVISED_COST")]
        [GridColumnAttribue(ColumnOrder = 9, ViewName = Constants.REPORT, Caption = "Revised_Cost", Visible = true)]
        public decimal? RevisedCost { get; set; }

        [Column("DAILY_AMORTIZATION")]
        [GridColumnAttribue(ColumnOrder = 10, ViewName = Constants.REPORT, Caption = "Daily_Amortization", Visible = true)]
        public decimal? DailyAmortization { get; set; }

        [Column("CUMULATIVE_AMORTIZATION")]
        [GridColumnAttribue(ColumnOrder = 11, ViewName = Constants.REPORT, Caption = "Cumulative_Amortisation", Visible = true)]
        public decimal? CumulativeAmortisation { get; set; }

        [Column("NOTIONAL")]
        [GridColumnAttribue(ColumnOrder = 12, ViewName = Constants.REPORT, Caption = "Notional", Visible = true)]
        public decimal? Notional { get; set; }

        [Column("FACTORED_NOTIONAL")]
        [GridColumnAttribue(ColumnOrder = 13, ViewName = Constants.REPORT, Caption = "FactoredNotional", Visible = true)]
        public decimal? FactoredNotional { get; set; }
    }
}
