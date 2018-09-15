﻿using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSXsharp.Tests
{
    [TestClass]
    public class PublicApiTest
    {
        #region [ Local properties/variables ]

        private const string _appKey = "6c490403-4b36-426a-941e-f157cba90875";

        private const string _appSecret = "ABIF41XN2Q6TIJWE1SN0O6TX04OEODVSSIZMZACR3VF1";

        public DsxClient _client;

        #endregion

        [TestInitialize()]
        public void Init()
        {            
            _client = new DsxClient(_appKey, _appSecret, new ExchangeOptions() { DemoMode = true });
        }

        [TestMethod]
        public void GetCurrencyPairs()
        {
            var r = _client.GetCurrencyPairsAsync(CancellationToken.None).Result;

            Assert.IsNotNull(r.Pairs);

            Assert.IsNotNull(r.ServerTime);
        }

        [TestMethod]
        public void GetOrderBookAsync()
        {
            var r = _client.GetOrderBookAsync("btcusd", CancellationToken.None).Result;
            
            Assert.IsNotNull(r.Orders);

            //Assert.IsTrue(r.Orders.ContainsKey["btcusd"]);
        }

        [TestMethod]
        public void GetTradesAsync()
        {
            var r = _client.GetTradesAsync("btcusd", CancellationToken.None).Result;

            Assert.IsNotNull(r.CurrencyTrades);

            //Assert.IsTrue(r.CurrencyTrades.ContainsKey["btcusd"]);
        }

        [TestMethod]
        public void TickerAsync()
        {
            var r = _client.TickerAsync("btcusd", CancellationToken.None).Result;

            Assert.IsNotNull(r.Ticks);

            //Assert.IsTrue(r.CurrencyTrades.ContainsKey["btcusd"]);
        }
    }
}
