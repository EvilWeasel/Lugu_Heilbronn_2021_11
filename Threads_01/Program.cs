using System;

namespace Threads_01
{
    class Program
    {
        static void Test02()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Help");
                Thread.Sleep(50);
            }
        }
        static void Test01()
        {
            Console.WriteLine("START");
            ThreadStart x = new(Test01);
            Thread t = new(x);
            t.Start();
            Console.WriteLine("STOPP");
        }

        static void Test03()
        {
            Thread t = new(Test02);
            t.IsBackground = true;
            Thread t2 = new(() => Console.WriteLine("HAHAHAHAHHAHA"));
            t2.IsBackground = true;
            Thread t3 = new(new ThreadStart(Test02));
            Console.WriteLine("A");
            // Test02();   //Syncron Test02 starten
            t.Start();  //Asyncron Test02 starten
            t2.Start();
            Console.WriteLine("B");
        }

        static void Test04()
        {

        }

        static void Main(string[] args)
        {
            Test03();




            Console.WriteLine("ENDE");
        }
    }
}



