namespace cspatterns
{
    #region

    using System.Diagnostics;

    using cspatterns.Classes;
    using cspatterns.Clients;

    using NodaTime;

    #endregion

    /// <summary>
    ///   The program.
    /// </summary>
    internal class Program
    {
        #region Methods

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args. 
        /// </param>
        private static void Main(string[] args)
        {
            var c = new SingletonClient();
            c.UseSingleton();

            var d = new LicenseClient();
            d.ExpiredLicense();
            d.LicenseIsValid();

            var x = new License(Instant.FromUtc(2012, 10, 17, 0, 0, 0), SystemClock.Instance);
            if (x.HasExpired)
            {
                Debug.WriteLine("Program License Expired");
            }

            var y = new DiaryClient();
            y.FormatTodayIsoUtc();
        }

        #endregion
    }
}