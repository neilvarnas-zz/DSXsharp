using Newtonsoft.Json;

namespace DSXsharp.Models
{
    public class Trade
    {
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public double TimeStamp { get; set; }

        [JsonProperty(PropertyName = "tid")]
        public string Tid { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
