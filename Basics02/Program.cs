using System;
using System.Collections.Generic;

namespace Basics02
{
    class Blubbliste
    {
        #region SINGLETON
        //Singleton
        private static Blubbliste _instance = null;

        // VORSICHT: NICHT THREADSICHER
        public static Blubbliste GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Blubbliste();
            }
            return _instance;
        }
        private Blubbliste()
        {
        }
        #endregion

        private List<Blubb> bliste = new List<Blubb>();
        public void Add(Blubb b)
        {
            bliste.Add(b);
        }
        public Blubb Get(int n)
        {
            if (bliste.Count < n)
                return bliste[n];
            else
                return null;
        }
    }

    static class StaticBlubbliste
    {
        static StaticBlubbliste()
        {

        }

        private static List<Blubb> bliste = new List<Blubb>();
        public static void Add(Blubb b)
        {
            bliste.Add(b);
        }
        public static Blubb Get(int n)
        {
            
            if (bliste.Count < n)
                return bliste[n];
            else
                return null;
        }
    }

    class Blubb
    {
        int a = 10; // Objekt-Member
        public void A() // Objekt-Member
        {
            Console.WriteLine(a);
        }
        static int b = 20; // Klassen-Member
        public static void B() // Klassen-Member
        {
            Console.WriteLine(b);
        }
    }
    class Program
    {
        // public static Blubbliste liste = new Blubbliste();

        public static void Test2()
        {
            StaticBlubbliste.Add(new Blubb());
            Blubbliste.GetInstance().Add(new Blubb());

            //   liste.Add(new Blubb());
        }

        public static void Test()
        {
            Blubb.B();
            Blubb b1 = new Blubb();
            b1.A();
            Blubb b2 = new Blubb();
            b2.A();
        }
        public static void Main(string[] args)
        {
            Test();
            Test();
        }
    }
}
