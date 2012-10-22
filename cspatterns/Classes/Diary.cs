namespace cspatterns.Classes
{
    #region

    using NodaTime;
    using NodaTime.Text;

    #endregion

    public class Diary
    {
        #region Fields

        private readonly CalendarSystem calendar;

        private readonly IClock clock;

        private readonly LocalDatePattern outputPattern = LocalDatePattern.CreateWithInvariantInfo("yyyy-MM-dd");

        private readonly DateTimeZone timeZone;

        #endregion

        #region Constructors and Destructors

        public Diary(IClock clock, CalendarSystem calendar, DateTimeZone timeZone)
        {
            this.clock = clock;
            this.calendar = calendar;
            this.timeZone = timeZone;
        }

        #endregion

        #region Public Methods and Operators

        public string FormatToday()
        {
            var d = this.clock.Now.InZone(this.timeZone, this.calendar).LocalDateTime.Date;
            return this.outputPattern.Format(d);
        }

        #endregion
    }
}