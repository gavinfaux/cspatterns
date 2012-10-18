namespace cspatterns.Classes
{
    #region

    using System;
    using System.Diagnostics;
    using System.Threading;

    #endregion

    /// <summary>
    ///   The singleton (NET 4.0).
    /// </summary>
    public class Singleton4
    {
        #region Static Fields

        /// <summary>
        ///   The instance.
        /// </summary>
        private static readonly Lazy<Singleton4> LazyInstance = new Lazy<Singleton4>(
            () => new Singleton4(), LazyThreadSafetyMode.ExecutionAndPublication);

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Prevents a default instance of the <see cref="Singleton4" /> class from being created. 
        ///   Prevents a default instance of the <see cref="Singleton" /> class from being created.
        /// </summary>
        private Singleton4()
        {
            Debug.WriteLine("Singleton4 Constructor");
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets the instance.
        /// </summary>
        public static Singleton4 Instance
        {
            get
            {
                return LazyInstance.Value;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   The say hi.
        /// </summary>
        public static void SayHi()
        {
            Debug.WriteLine("Singleton4 says Hi!");
        }

        /// <summary>
        ///   The do something.
        /// </summary>
        public void DoSomething()
        {
            Debug.WriteLine("Singleton4 DoSomething");
        }

        #endregion
    }
}