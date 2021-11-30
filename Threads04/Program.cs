
using System.Collections.Concurrent;

namespace Threads04
{
    class Program
    {
        // NICHT THREADSICHER
        static List<int> zahlen = new List<int>();

        //static ConcurrentBag<int> zahlen = new ConcurrentBag<int>();




        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
                {
                    lock (zahlen)
                    {
                        for (int i = 0; i < 500; i++)
                        {
                            zahlen.Add(i);
                            Thread.Sleep(10);

                        }
                    }
                });
            Thread t2 = new Thread(() =>
                {
                    lock (zahlen)
                    {
                        for (int i = 0; i < 250; i++)
                        {
                            zahlen.Add(i);
                            Thread.Sleep(10);

                        }
                    }
                });

            Thread t3 = new Thread(() =>
            {
                lock (zahlen)
                {
                    for (int i = 0; i < 250; i++)
                    {
                        zahlen.Add(i);
                        Thread.Sleep(10);

                    }
                }
            });


            List<Thread> tlist = new List<Thread>() { t1 , t2 , t3 };
            tlist.ForEach(t => t.Start());
            tlist.ForEach(t => t.Join());
            Console.WriteLine("Count: " + zahlen.Count);



        }
    }
}