using Newtonsoft.Json;
using System.Collections.Generic;

namespace DSXsharp.Models
{
    public class Ticker
    {
        [JsonProperty(PropertyName = "ticks")]
        public Dictionary<string, Tick> Ticks { get; set; }
    }
}
