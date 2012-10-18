using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cspatterns.Classes
{
    using System.Diagnostics;

    using NodaTime;
    using NodaTime.Text;

    public class Diary
    {
        private readonly LocalDatePattern outputPattern = LocalDatePattern.CreateWithInvariantInfo("yyyy-MM-dd");

        private readonly IClock clock;

        private readonly CalendarSystem calendar;

        private readonly DateTimeZone timeZone;

        public Diary(IClock clock, CalendarSystem calendar, DateTimeZone timeZone)
        {
            this.clock = clock;
            this.calendar = calendar;
            this.timeZone = timeZone;
        }

        public string FormatToday()
        {
            var d = clock.Now.InZone(timeZone, calendar).LocalDateTime.Date;
            return  outputPattern.Format(d);

        }
    }
}
