namespace cspatterns.Classes
{
    #region

    using System.Diagnostics;

    #endregion

    /// <summary>
    ///   The singleton. - use case e.g. a clock
    /// </summary>
    public class Singleton
    {
        #region Constructors and Destructors

        /// <summary>
        ///   Prevents a default instance of the <see cref="Singleton" /> class from being created.
        /// </summary>
        private Singleton()
        {
            Debug.WriteLine("Singleton Constructor");
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets the instance.
        /// </summary>
        public static Singleton Instance
        {
            get
            {
                return SingletonHolder.TheInstance;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///   The say hi.
        /// </summary>
        public static void SayHi()
        {
            Debug.WriteLine("Singleton says Hi!");
        }

        /// <summary>
        ///   The do something.
        /// </summary>
        public void DoSomething()
        {
            Debug.WriteLine("Singleton DoSomething");
        }

        #endregion

        /// <summary>
        ///   The singleton holder.
        /// </summary>
        private static class SingletonHolder
        {
            #region Static Fields

            /// <summary>
            ///   The instance.
            /// </summary>
            internal static readonly Singleton TheInstance = new Singleton();

            #endregion

            #region Constructors and Destructors

            /// <summary>
            ///   Initializes static members of the <see cref="SingletonHolder" /> class. 
            ///   Initializes static members of the <see cref="Singleton" /> class.
            /// </summary>
            static SingletonHolder()
            {
            }

            #endregion
        }
    }
}