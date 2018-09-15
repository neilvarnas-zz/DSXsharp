using Newtonsoft.Json;

namespace DSXsharp.Models
{
    public class Tick
    {
        [JsonProperty(PropertyName = "high")]
        public decimal High { get; set; }

        [JsonProperty(PropertyName = "low")]
        public decimal Low { get; set; }

        [JsonProperty(PropertyName = "last")]
        public decimal Last { get; set; }

        [JsonProperty(PropertyName = "buy")]
        public decimal Buy { get; set; }

        [JsonProperty(PropertyName = "sell")]
        public decimal Sell { get; set; }

        [JsonProperty(PropertyName = "updated")]
        public double Updated { get; set; }

        [JsonProperty(PropertyName = "avg")]
        public decimal Average { get; set; }

        [JsonProperty(PropertyName = "vol")]
        public decimal Volume { get; set; }

        [JsonProperty(PropertyName = "vol_cur")]
        public decimal VolCur { get; set; }
    }
}
