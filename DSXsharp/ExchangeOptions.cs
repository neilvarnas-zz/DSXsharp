namespace DSXsharp
{
    public class ExchangeOptions
    {
        #region [ Constructor ]

        public ExchangeOptions()
        {
            this.DemoMode = false;
        }

        #endregion

        /// <summary>
        /// Indicates whther to use demo account for testing purposes. 
        /// </summary>
        public bool DemoMode { get; set; }
    }
}
