namespace cspatterns
{
    #region

    using System.Diagnostics;

    using cspatterns.Classes;
    using cspatterns.Clients;

    using Ninject;

    using NodaTime;

    #endregion

    internal class Program
    {
        #region Methods

        private static void DiaryClientTest()
        {
            var y = new DiaryClient();
            y.FormatTodayIsoUtc();
        }

        private static void IOCTest()
        {
            // we did not have to amend anything when when IClock was added to DiaryPresenter constructor, the IOC container (Ninject) resolved it for us
            var i = new StandardKernel();
            i.Bind<IClock>().ToConstant(SystemClock.Instance).InSingletonScope();
            i.Bind<DateTimeZone>().ToConstant(DateTimeZone.GetSystemDefault());
            i.Bind<Instant>().ToConstant(Instant.FromUtc(2000, 1, 1, 0, 0, 0));
            i.Bind<CalendarSystem>().ToConstant(CalendarSystem.Iso);
            var p = i.Get<DiaryPresenter>();
            p.Start();
        }

        private static void InjectorTest()
        {
            // we had to amend injector class when IClock was added to DiaryPresenter constructor
            var i = new Injector();
            var p = i.CreateDiaryPresenter();
            p.Start();
        }

        private static void LicenseClientTest()
        {
            var d = new LicenseClient();
            d.ExpiredLicense();
            d.LicenseIsValid();
        }

        private static void LicenseTest()
        {
            var x = new License(Instant.FromUtc(2012, 10, 17, 0, 0, 0), SystemClock.Instance);
            if (x.HasExpired)
            {
                Debug.WriteLine("Program License Expired");
            }
        }

        private static void Main(string[] args)
        {
            

            SingletonTest();

            

            #region Interfaces

            LicenseClientTest();

            LicenseTest();

            DiaryClientTest();

            #endregion

            #region DependancyInjection

            ManualDependencyInjectionTest();

            #endregion

            #region IOC

            InjectorTest();

            IOCTest();

            #endregion
        }

        private static void ManualDependencyInjectionTest()
        {
            var c = SystemClock.Instance;
            var l = new License(Instant.UnixEpoch, c);
            var d = new Diary(c, CalendarSystem.Iso, DateTimeZone.GetSystemDefault());
            var p = new DiaryPresenter(c, d, l);
        }

        private static void SingletonTest()
        {
            var s = new SingletonClient();
            s.UseSingleton();
        }

        #endregion
    }
}