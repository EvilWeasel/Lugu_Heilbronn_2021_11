using System;

namespace Delegaten01
{
    class Program
    {

        struct Person
        {
            public int Id { get; set; }
            public string Vorname { get; set; }
            public string Nachname { get; set; }
        }

        static void Test5(Person a, int b)
        {
            a.Vorname = "Horst";
            b = 20;
        }
        static void Test6()
        {
            int x = 10;
            Person p = new Person();
            p.Vorname = "Max";
            Test5(p,x);
            Console.WriteLine(p.Vorname);
        }

        // Unterprogramm, Prozedur, Methode
        // Funktion
        static void Test4(out int b)
        {
            // Console.WriteLine(b);
            // b muss nicht initialisiert sein!

            // Initialisierung von b am Ende der Methode!!!
            b = 10;
            Console.WriteLine(b);
        }

        static void Test3(ref int a /*, out int b*/)
        {
            Console.WriteLine(a);
        }

        static void Test2(int a , int b = 1)
        {

        }

        static void Test()
        {
            int x;
            int y = 20;

            Test2(a: 3, b: 2);
            Test3(ref y /*, out y*/);
            Test4(out x);

        }


        // Value-Datentypen
        // Referenz-Datentypen
        
        // class, struct


        static void Main(string[] args)
        {
            Test6(); 
        }
    }
}
