namespace cspatterns.Classes
{
    #region

    using System.Diagnostics;

    #endregion

    public class Singleton
    {
        #region Constructors and Destructors

        private Singleton()
        {
            Debug.WriteLine("Singleton Constructor");
        }

        #endregion

        #region Public Properties

        public static Singleton Instance
        {
            get
            {
                return SingletonHolder.TheInstance;
            }
        }

        #endregion

        #region Public Methods and Operators

        public static void SayHi()
        {
            Debug.WriteLine("Singleton says Hi!");
        }

        public void DoSomething()
        {
            Debug.WriteLine("Singleton DoSomething");
        }

        #endregion

        private static class SingletonHolder
        {
            #region Static Fields

            /// <summary>
            ///   The instance.
            /// </summary>
            internal static readonly Singleton TheInstance = new Singleton();

            #endregion

            #region Constructors and Destructors

            static SingletonHolder()
            {
            }

            #endregion
        }
    }
}