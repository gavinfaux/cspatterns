using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cspatterns.Clients
{
    using System.Diagnostics;

    using NUnit.Framework;

    using NodaTime;
    using NodaTime.TimeZones;
    using NodaTime.Testing;

    using cspatterns.Classes;

    [TestFixture]
    public class DiaryClient
    {


        [Test]
        public void FormatTodayIsoUtc()
        {
            var c = new StubClock(Instant.UnixEpoch);
            var d = new Diary(c, CalendarSystem.Iso, DateTimeZone.Utc);
            string t = d.FormatToday();
            Assert.AreEqual("1970-01-01",t);
            Debug.WriteLine("Diary says FormatTodayIsoUtc is:" + t);

        }

        [Test]
        public void FormatTodayIsoNegativeOffset()
        {
            var c = new StubClock(Instant.UnixEpoch);
            var z = DateTimeZone.ForId("America/New_York");
            var d = new Diary(c, CalendarSystem.Iso, z);
            string t = d.FormatToday();
            Assert.AreEqual("1969-12-31", t);
            Debug.WriteLine("Diary says FormatTodayIsoUtc is:" + t);

        }


    }
}
