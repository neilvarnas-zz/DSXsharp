using System.Threading;
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
    }
}
