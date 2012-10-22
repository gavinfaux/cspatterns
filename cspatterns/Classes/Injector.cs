namespace cspatterns.Classes
{
    // Example : This class defines all dependencies separately (for each type)
    // Code is bad as still have hard coded dependencies and is ugly, we have to amend for each dependency change
    #region

    using cspatterns.Clients;

    using NodaTime;

    #endregion

    public class Injector
    {
        #region Public Methods and Operators

        public CalendarSystem CreateCalenderSystem()
        {
            return CalendarSystem.Iso;
        }

        public IClock CreateClock()
        {
            return SystemClock.Instance;
        }

        public DateTimeZone CreateDateTimeZone()
        {
            return DateTimeZone.GetSystemDefault();
        }

        public Diary CreateDiary()
        {
            return new Diary(this.CreateClock(), this.CreateCalenderSystem(), this.CreateDateTimeZone());
        }

        public DiaryPresenter CreateDiaryPresenter()
        {
            return new DiaryPresenter(this.CreateClock(), this.CreateDiary(), this.CreateLicence());
        }

        public License CreateLicence()
        {
            return new License(Instant.UnixEpoch, this.CreateClock());
        }

        #endregion
    }
}