using DSXsharp.Models;
using System.Threading;
using System.Threading.Tasks;

namespace DSXsharp
{
    /// <summary>
    /// Public API methods.
    /// </summary>
    public interface PublicAPI
    {
        /// <summary>
        /// This method provides common information about available currency pairs, 
        /// such as the maximum number of digits after the decimal point for price and volume, 
        /// the minimum price, the maximum price, the minimum transaction size, 
        /// whether the pair is tradeable and the fee in percent for each pair.
        /// </summary>
        /// <param name="cancellationtoken">Cancellation token.</param>
        /// <returns><see cref="CurrencyPairs"/>.</returns>
        Task<CurrencyPairs> GetCurrencyPairsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// This method provides full order book for currency pair(s) which represents 
        /// current active orders on the currency pair.
        /// </summary>
        /// <param name="pair">Currency pair. Example: btcusd</param>
        /// <param name="cancellationtoken">Cancellation token.</param>
        /// <returns><see cref="OrderBook"/></returns>
        Task<OrderBook> GetOrderBookAsync(string pair, CancellationToken cancellationToken);

        /// <summary>
        /// This method provides information about the last trades for currency pairs.
        /// </summary>
        /// <param name="pair">Currency pair. Example: btcusd</param>
        /// <param name="cancellationtoken">Cancellation token.</param>
        /// <returns><see cref="Trades"/>.</returns>
        Task<Trades> GetTradesAsync(string pair, CancellationToken cancellationToken);

        /// <summary>
        /// This method provides additional in-time information about currency pairs for the past 24 hours.
        /// </summary>
        /// <param name="pair">Currency pair. Example: btcusd</param>
        /// <param name="cancellationtoken">Cancellation token.</param>
        /// <returns><seealso cref="Ticker"/>.</returns>
        Task<Ticker> TickerAsync(string pair, CancellationToken cancellationToken);
    }
}
