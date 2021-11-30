using System;
using System.IO;

namespace GarbageCollector01
{

    class Person : IDisposable
    {
        public Person()
        {
            Id = 1;
            Vorname = "Max";
            Nachname = "Mustermann";
        }
        // Wird vom GC getriggert
        ~Person()
        {
            // Datei schließen
            // DB schließen

            Console.WriteLine($"Person {Id} destruct");
        }
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        public void Dispose()
        {
            Console.WriteLine($"Person {Id} dispose");
            GC.SuppressFinalize(this);
        }
    }


    class Program
    {
        static void Test02()
        { 
            // Dispose
            using (Person p = new Person())
            {
                Console.WriteLine("USING P");
            } // p.Dispose()

            using(StreamWriter w = new StreamWriter(@"c:\temp\test.txt"))
            {
                w.WriteLine("TEST TEST");
            } // w.Dispose(); => w.Close(); => w.Flush();
            
        }

        static void Test01()
        {
            Person p;
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine("I:" + i);
                p = new Person() { Id = i };
 
                // GC.KeepAlive(p);
                // GC.SuppressFinalize(p);
                // GC.Collect();
            }
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("TEST01 START");
            //Test01();
            //Console.WriteLine("TEST01 ENDE");

            Test02();
            GC.Collect(); // Garbage Collection starten!

            Console.ReadKey();
        }

    }
}
