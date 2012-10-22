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
    public class DiaryClient
    {
        #region Public Methods and Operators

        [Test]
        public void FormatTodayIsoNegativeOffset()
        {
            var c = new StubClock(Instant.UnixEpoch);
            var z = DateTimeZone.ForId("America/New_York");
            var d = new Diary(c, CalendarSystem.Iso, z);
            var t = d.FormatToday();
            Assert.AreEqual("1969-12-31", t);
            Debug.WriteLine("Diary says FormatTodayIsoUtc is:" + t);
        }

        [Test]
        public void FormatTodayIsoUtc()
        {
            var c = new StubClock(Instant.UnixEpoch);
            var d = new Diary(c, CalendarSystem.Iso, DateTimeZone.Utc);
            var t = d.FormatToday();
            Assert.AreEqual("1970-01-01", t);
            Debug.WriteLine("Diary says FormatTodayIsoUtc is:" + t);
        }

        #endregion
    }
}