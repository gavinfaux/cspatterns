namespace cspatterns.Classes
{
    #region

    using NodaTime;

    #endregion

    /// <summary>
    ///   The license.
    /// </summary>
    public class License
    {
        #region Fields

        /// <summary>
        ///   The clock.
        /// </summary>
        private readonly IClock clock;

        /// <summary>
        ///   The expires.
        /// </summary>
        private readonly Instant expires;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="License"/> class.
        /// </summary>
        /// <param name="expires">
        /// The expires. 
        /// </param>
        /// <param name="clock">
        /// The clock. 
        /// </param>
        /// <remarks>Using NodaTime interfaces... </remarks>
        public License(Instant expires, IClock clock)
        {
            this.expires = expires;
            this.clock = clock;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets a value indicating whether has expired.
        /// </summary>
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