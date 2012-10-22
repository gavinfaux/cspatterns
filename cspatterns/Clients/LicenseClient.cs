namespace cspatterns.Clients
{
    #region

    using System.Diagnostics;

    using cspatterns.Classes;

    using NodaTime;
    using NodaTime.Testing;

    using NUnit.Framework;

    #endregion

    [TestFixture]
    public class LicenseClient
    {
        #region Public Methods and Operators

        [Test]
        public void ExpireAtExactInstance()
        {
            var expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            var clock = new StubClock(expiry);
            var license = new License(expiry, clock);
            Debug.WriteLine("License expired");
            Assert.IsTrue(license.HasExpired);
        }

        [Test]
        public void ExpiredLicense()
        {
            var expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            var clock = new StubClock(expiry + Duration.One);
            var license = new License(expiry, clock);
            Debug.WriteLine("License expired");
            Assert.IsTrue(license.HasExpired);
        }

        [Test]
        public void LicenseIsValid()
        {
            var expiry = Instant.FromUtc(2000, 1, 1, 0, 0, 0);
            var clock = new StubClock(expiry - Duration.One);
            var license = new License(expiry, clock);
            Debug.WriteLine("License valid");
            Assert.IsFalse(license.HasExpired);
        }

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