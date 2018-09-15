using Newtonsoft.Json;
using System.Collections.Generic;

namespace DSXsharp.Models
{
    public class Trades
    {
        [JsonProperty(PropertyName = "currencyTrades")]
        public Dictionary<string, IEnumerable<Trade>> CurrencyTrades { get; set; }
    }
}
