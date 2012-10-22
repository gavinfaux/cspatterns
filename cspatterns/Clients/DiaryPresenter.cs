namespace cspatterns.Clients
{
    #region

    using System.Diagnostics;

    using cspatterns.Classes;

    using NodaTime;

    #endregion

    public class DiaryPresenter
    {
        #region Constructors and Destructors

        public DiaryPresenter(IClock clock, Diary diary, License license)
        {
            Debug.WriteLine("DiaryPresenter Constructor");
        }

        #endregion

        #region Public Methods and Operators

        public void Start()
        {
            Debug.WriteLine("DiaryPresenter Start");
        }

        #endregion
    }
}