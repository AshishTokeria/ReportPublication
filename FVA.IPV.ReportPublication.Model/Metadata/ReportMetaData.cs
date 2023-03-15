using Newtonsoft.Json;

namespace FVA.IPV.ReportPublication.Model.Metadata
{
    public class ReportMetaData
    {
        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("business_date")]
        public string? Date { get; set; }
    }
}
