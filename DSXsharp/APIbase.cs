using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DSXsharp
{
    public abstract class APIbase
    {
        #region [ Properties/Variables ]

        /// <summary>
        /// Private Http client set up.
        /// </summary>
        private Lazy<HttpClient> client =
          new Lazy<HttpClient>(() =>
          {
              var _client = new HttpClient() { BaseAddress = BaseAddress };

              _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

              return _client;
          });

        /// <summary>
        /// Https client public.
        /// </summary>
        internal HttpClient Client => client.Value;

        /// <summary>
        /// Dsx exchange base url.
        /// </summary>
        private const string DsxUrl = "https://dsx.uk";

        /// <summary>
        /// Application key.
        /// </summary>
        private string _appKey;

        /// <summary>
        /// Application secret key.
        /// </summary>
        private string _appSecret;

        /// <summary>
        /// TBaseAddress.
        /// </summary>
        private static Uri BaseAddress => new Uri($"{DsxUrl}/mapi/");

        private byte[] CodeKey
            {
                get => Encoding.ASCII.GetBytes(this._appSecret);
            }

        /// <summary>
        /// Get current UNIX time in milliseconds.
        /// </summary>
        private double CurrentUnix
        {
            get => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        #endregion

        #region [ Methods ]

        /// <summary>
        /// Initialise.
        /// </summary>
        /// <param name="appKey">Application key.</param>
        /// <param name="appSecret">Application secret key.</param>
        public void Init(string appKey, string appSecret)
        {
            _appKey = appKey;
            _appSecret = appSecret;

            // Obligatory body parameter. A positive integer value. A good nonce value is the current UNIX time in milliseconds.
            Client.DefaultRequestHeaders.Add("nonce", CurrentUnix.ToString());

            // Header parameter. POST data (param=val&param1=val1) signed by a secret key according to HMAC-SHA512 method and converted to Base64 string.
            Client.DefaultRequestHeaders.Add("Sign", GetSignature());
        }

        /// <summary>
        /// Post query to DSX API.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="cancellationToken">Cancellation tToken.</param>
        /// <returns></returns>
        public async Task<string> RunQueryAsync(string uri, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(uri))
                    throw new ArgumentNullException("uri", "Query uri can't be empty!");

                using (var response = await Client.GetAsync(uri).ConfigureAwait(false))
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    return responseData;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [ Helpers ]

        /// <summary>
        /// Header parameter. POST data (param=val&param1=val1) signed by a secret key according 
        /// to HMAC-SHA512 method and converted to Base64 string.
        /// </summary>
        /// <returns></returns>
        internal string GetSignature()
        {
            try
            {
                byte[] sig = new HMACSHA512(CodeKey)
                                    .ComputeHash(Encoding.UTF8.GetBytes("param=val&param1=val1"));

                return System.Text.Encoding.UTF8.GetString(sig);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
