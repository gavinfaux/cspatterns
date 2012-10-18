namespace cspatterns.Clients
{
    #region

    using System.Diagnostics;

    using cspatterns.Classes;

    using NodaTime;
    using NodaTime.Testing;

    using NUnit.Framework;

    #endregion

    /// <summary>
    ///   The date time interface client.
    /// </summary>
    [TestFixture]
    public class LicenseClient
    {
        #region Public Methods and Operators

        /// <summary>
        /// The expire at exact instance.
        /// </summary>
        [Test]
        public void ExpireAtExactInstance()
        {
            var expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            var clock = new StubClock(expiry);
            var license = new License(expiry, clock);
            Debug.WriteLine("License expired");
            Assert.IsTrue(license.HasExpired);
        }

        /// <summary>
        /// The expired license.
        /// </summary>
        [Test]
        public void ExpiredLicense()
        {
            var expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            var clock = new StubClock(expiry + Duration.One);
            var license = new License(expiry, clock);
            Debug.WriteLine("License expired");
            Assert.IsTrue(license.HasExpired);
        }

        /// <summary>
        /// The license is valid.
        /// </summary>
        [Test]
        public void LicenseIsValid()
        {
            var expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            var clock = new StubClock(expiry - Duration.One);
            var license = new License(expiry, clock);
            Debug.WriteLine("License valid");
            Assert.IsFalse(license.HasExpired);
        }

        /// <summary>
        /// The license is valid but then expires.
        /// </summary>
        [Test]
        public void LicenseIsValidButThenExpires()
        {
            var expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            var clock = new StubClock(expiry - Duration.One);
            var license = new License(expiry, clock);
            Debug.WriteLine("License valid");
            Assert.IsFalse(license.HasExpired);
            clock.AdvanceTicks(1);
            Assert.IsTrue(license.HasExpired);
            Debug.WriteLine("License expired");
        }

        #endregion
    }
}