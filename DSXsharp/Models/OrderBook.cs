using Newtonsoft.Json;
using System.Collections.Generic;

namespace DSXsharp.Models
{
    public class OrderBook
    {
        public Dictionary<string, Dictionary<string, IEnumerable<IEnumerable<double>>>> Orders { get; set; }
    }
}
