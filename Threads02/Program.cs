namespace Threads02
{
    class Program
    {

        static void Worker1()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Hallo ");
                    Thread.Sleep(200);

                }
                catch (ThreadInterruptedException ex)
                {

                    Console.WriteLine("Worker1 Interrupted!");
                    Thread.Sleep(2000);
                }
            }
        }

        static void Worker2()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Welt");
                    Thread.Sleep(200);

                }

            }
            catch (ThreadInterruptedException ex)
            {

                Console.WriteLine("Worker2 Interrupted!");

            }
        }


        static void Test01()
        {
            Thread t1 = new(Worker1);
            Thread t2 = new(Worker2);
            t1.Start();
            t2.Start();
            bool run = true;
            ConsoleKeyInfo cki;
            while (run)
            {
                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.F4:
                        run = false;
                        t1.Interrupt();
                        t2.Interrupt();
                        break;
                    case ConsoleKey.F1:
                        t1.Interrupt();
                        break;
                    case ConsoleKey.F2:
                        t2.Interrupt();
                        break;
                }
                Thread.Sleep(20);
            }
            Console.WriteLine("ENDE TEST01");
        }


        static void Main(string[] args)
        {
            Test01();
        }
    }
}