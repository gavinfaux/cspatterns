﻿namespace cspatterns.Clients
{
    #region

    using System.Diagnostics;

    using cspatterns.Classes;

    using NUnit.Framework;

    #endregion

    [TestFixture]
    public class SingletonClient
    {
        #region Public Methods and Operators

        [Test]
        public void UseSingleton()
        {
            Singleton.SayHi();
            Debug.WriteLine("Start Singleton Test");
            var s1 = Singleton.Instance;
            s1.DoSomething();
            var s2 = Singleton.Instance;
            s2.DoSomething();
            Assert.AreSame(s1, s2);
        }

        [Test]
        public void UseSingleton4()
        {
            Singleton4.SayHi();
            Debug.WriteLine("Start Singleton4 Test");
            var s1 = Singleton4.Instance;
            s1.DoSomething();
            var s2 = Singleton4.Instance;
            s2.DoSomething();
            Assert.AreSame(s1, s2);
        }

        #endregion
    }
}