namespace Threads03
{
    class Program
    {
        static int Konto = 1000;
        static Random rnd = new Random();

        static object ampel = new object();

        static Semaphore sema = new(0,1);






        static void Main(string[] args)
        {
            Konto = 1000;
            Thread t1 = new(() =>
            {

                for (int i = 0; i < 10; i++)
                {
                    // synchronized
                    // Monitor.Enter(ampel)
                    //sema.WaitOne();
                    lock (ampel)
                    {

                        int k = Konto;
                        Thread.Sleep(rnd.Next(20, 101));
                        k += 100;
                        Thread.Sleep(rnd.Next(20, 101));
                        Konto = k;
                    }
                    //sema.Release();
                    // Monitor(ampel)
                    Thread.Sleep(rnd.Next(20, 101));
                }
            }

            );

            Thread t2 = new(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    lock (ampel)
                    {

                        int k = Konto;
                        Thread.Sleep(rnd.Next(20, 101));
                        k -= 100;
                        Thread.Sleep(rnd.Next(20, 101));
                        Konto = k;
                    }
                    Thread.Sleep(rnd.Next(20, 101));
                }
            });

            Console.WriteLine($"KONTOSTAND ANFANG: " + Konto);
            t1.Start();
            t2.Start();
            t1.Join(); t2.Join();
            Console.WriteLine($"KONTOSTAND ENDE: " + Konto);
        }
    }
}