using Newtonsoft.Json;
using System.Collections.Generic;

namespace DSXsharp.Models
{
    public class CurrencyPairs
    {
        [JsonProperty(PropertyName = "server_time")]
        public string ServerTime { get; set; }

        [JsonProperty(PropertyName = "pairs")]
        public IDictionary<string, CurrencyPair> Pairs{ get; set; }
}
}
