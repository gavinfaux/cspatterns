namespace cspatterns.Classes
{
    #region

    using System;
    using System.Diagnostics;
    using System.Threading;

    #endregion

    /// <summary>
    ///   (NET 4.0).
    /// </summary>
    public class Singleton4
    {
        #region Static Fields

        private static readonly Lazy<Singleton4> LazyInstance = new Lazy<Singleton4>(
            () => new Singleton4(), LazyThreadSafetyMode.ExecutionAndPublication);

        #endregion

        #region Constructors and Destructors

        private Singleton4()
        {
            Debug.WriteLine("Singleton4 Constructor");
        }

        #endregion

        #region Public Properties

        public static Singleton4 Instance
        {
            get
            {
                return LazyInstance.Value;
            }
        }

        #endregion

        #region Public Methods and Operators

        public static void SayHi()
        {
            Debug.WriteLine("Singleton4 says Hi!");
        }

        public void DoSomething()
        {
            Debug.WriteLine("Singleton4 DoSomething");
        }

        #endregion
    }
}