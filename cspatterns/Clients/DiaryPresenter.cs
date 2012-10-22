namespace cspatterns.Clients
{
    #region

    using System.Diagnostics;

    using cspatterns.Classes;

    using NodaTime;

    #endregion

    public class DiaryPresenter
    {
        private readonly IClock clock;

        private readonly Diary diary;

        private readonly License license;

        #region Constructors and Destructors

        public DiaryPresenter(IClock clock, Diary diary, License license)
        {
            this.clock = clock;
            this.diary = diary;
            this.license = license;
            Debug.WriteLine("DiaryPresenter Constructor");
        }

        #endregion

        #region Public Methods and Operators

        public void Start()
        {
            Debug.WriteLine("DiaryPresenter Start");
            Debug.WriteLine(clock.Now);
            Debug.WriteLine(diary.FormatToday());
            Debug.WriteLine(license.HasExpired);
        }

        #endregion
    }
}