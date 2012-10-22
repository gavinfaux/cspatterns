namespace cspatterns.Classes
{
    #region

    using NodaTime;

    #endregion

    public class License
    {
        #region Fields

        private readonly IClock clock;

        private readonly Instant expires;

        #endregion

        #region Constructors and Destructors

        /// <remarks>
        /// Using NodaTime interfaces...
        /// </remarks>
        public License(Instant expires, IClock clock)
        {
            this.expires = expires;
            this.clock = clock;
        }

        #endregion

        #region Public Properties

        public bool HasExpired
        {
            get
            {
                // would not have found the > vs >= bug without interfaces
                return this.clock.Now >= this.expires;
            }
        }

        #endregion
    }
}