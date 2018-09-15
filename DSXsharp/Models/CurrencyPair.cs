using Newtonsoft.Json;

namespace DSXsharp.Models
{
    public class CurrencyPair
    {
        /// <summary>
        /// Decimal places example value "5".
        /// </summary>
        [JsonProperty(PropertyName = "decimal_places")]
        public double DecimalPlaces { get; set; }

        /// <summary>
        /// Min price example value "5.00000".
        /// </summary>
        [JsonProperty(PropertyName = "min_price")]
        public decimal MinPrice { get; set; }

        /// <summary>
        /// Max price example value "201.00000".
        /// </summary>
        [JsonProperty(PropertyName = "max_price")]
        public decimal MaxPrice { get; set; }

        /// <summary>
        /// Min price example value "0.0100000000".
        /// </summary>
        [JsonProperty(PropertyName = "min_amount")]
        public decimal MinAmount { get; set; }

        /// <summary>
        /// Hidden amount examle value "0".
        /// </summary>
        [JsonProperty(PropertyName = "hidden")]
        public double Hidden { get; set; }

        /// <summary>
        /// Fee amount example value "0".
        /// </summary>
        [JsonProperty(PropertyName = "fee")]
        public double Fee { get; set; }

        /// <summary>
        /// Amount decimal places example value "3".
        /// </summary>
        [JsonProperty(PropertyName = "amount_decimal_places")]
        public double AmountDecimalPlaces { get; set; }

        /// <summary>
        /// Quoted currency example value "EUR".
        /// </summary>
        [JsonProperty(PropertyName = "quoted_currency")]
        public string QuotedCurrency { get; set; }

        /// <summary>
        /// Base currency example value "BTG".
        /// </summary>
        [JsonProperty(PropertyName = "base_currency")]
        public string BaseCurrency { get; set; }
    }
}
