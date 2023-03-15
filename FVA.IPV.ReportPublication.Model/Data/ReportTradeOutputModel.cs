using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVA.IPV.ReportPublication.Model.Data
{
    [Table("FVA_IPV_TRADE_OUTPUT")]
    public class ReportTradeOutputModel
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("HEADER_ID")]
        public int HeaderId { get; set; }

        [Column("TRADE_ID")]
        public string? TradeId { get; set; }

        [Column("EVENT_TYPE")]
        public string? EventType { get; set; }

        [Column("ISIN")]
        public string? Isin { get; set; }

        [Column("NOTIONAL")]
        public decimal? Notional { get; set; }

        [Column("FACTORED_NOTIONAL")]
        public decimal? FactoredNotional { get; set; }

        [Column("PD_CRYSTALISED")]
        public decimal? PdCrystalised { get; set; }

        [Column("GAIN_LOSS")]
        public decimal? GainLoss { get; set; }

    }
}
