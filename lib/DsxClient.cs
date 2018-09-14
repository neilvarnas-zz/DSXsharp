using DSXsharp.Models;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DSXsharp
{
    public class DsxClient : APIbase, PublicAPI
    {
        #region [ Constructor ]

        /// <summary>
        /// Constructor
        /// </summary>
        public DsxClient(string appKey, string appSecret, ExchangeOptions options)
        {
            if (options == null)
                options = new ExchangeOptions();

            base.Init(appKey, appSecret);
        }

        #endregion

        #region [ Public API implementation ]

        /// <summary>
        /// This method provides common information about available currency pairs, 
        /// such as the maximum number of digits after the decimal point for price and volume, 
        /// the minimum price, the maximum price, the minimum transaction size, 
        /// whether the pair is tradeable and the fee in percent for each pair.
        /// <see cref="https://dsx.docs.apiary.io/#reference/public-market-data/currency-pairs/currency-pairs-request"/>
        /// </summary>
        /// <returns></returns>
        public async Task<CurrencyPairs> GetCurrencyPairsAsync(CancellationToken cancellationToken)
        {
            try
            {
                using (var response = await base.Client.GetAsync("info").ConfigureAwait(false))
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(responseData))
                        return new CurrencyPairs();

                    return JsonConvert.DeserializeObject<CurrencyPairs>(responseData);
                }                
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method provides full order book for currency pair(s) which represents 
        /// current active orders on the currency pair.
        /// </summary>
        /// <param name="pair">Currency pair. Example: btcusd</param>
        /// <param name="cancellationtoken">Cancellation token.</param>
        /// <returns><see cref="OrderBook"/></returns>
        public async Task<OrderBook> GetOrderBookAsync(string pair, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(pair))
                    throw new ArgumentNullException("pair", "Pair can't be null!");

                using (var response = await base.Client.GetAsync($"depth/{pair}").ConfigureAwait(false))
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(responseData))
                        return new OrderBook();

                    return JsonConvert.DeserializeObject<OrderBook>(responseData);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method provides information about the last trades for currency pairs.
        /// </summary>
        /// <param name="pair">Currency pair. Example: btcusd</param>
        /// <param name="cancellationtoken">Cancellation token.</param>
        /// <returns><see cref="Trades"/></returns>
        public async Task<Trades> GetTradesAsync(string pair, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(pair))
                    throw new ArgumentNullException("pair", "Pair can't be null!");

                using (var response = await base.Client.GetAsync($"trades/{pair}").ConfigureAwait(false))
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(responseData))
                        return new Trades();

                    return JsonConvert.DeserializeObject<Trades>(responseData);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This method provides additional in-time information about currency pairs for the past 24 hours.
        /// </summary>
        /// <param name="pair">Currency pair. Example: btcusd</param>
        /// <param name="cancellationtoken">Cancellation token.</param>
        /// <returns><seealso cref="Ticker"/>.</returns>
        public async Task<Ticker> TickerAsync(string pair, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(pair))
                    throw new ArgumentNullException("pair", "Pair can't be null!");

                using (var response = await base.Client.GetAsync($"ticker/{pair}").ConfigureAwait(false))
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    if (string.IsNullOrEmpty(responseData))
                        return new Ticker();

                    return JsonConvert.DeserializeObject<Ticker>(responseData);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
