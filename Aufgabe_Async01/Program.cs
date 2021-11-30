namespace Aufgabe_Async01
{
    class Program
    {



        static void Main(string[] args)
        {
            Thread t2 = null;
            Thread t1 = new Thread(() =>
            {
                try
                {
                    for (int i = 0; i < 200; i++)
                    {
                        Lager.Produzieren();
                        Thread.Sleep(50);
                    }
                    t2.Interrupt();

                }
                catch (ThreadInterruptedException ex)
                {
                    Console.WriteLine("Produzent fertig");
                    
                }
            });


            t2 = new Thread(() =>
            {
                try
                {
                    for (int i = 0; i < 200; i++)
                    {
                        Lager.Entnehmen();
                        Thread.Sleep(50);
                    }
                    t1.Interrupt();

                }
                catch (ThreadInterruptedException ex)
                {
                    Console.WriteLine("Entnahme fertig");


                }
            });


            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine("Programm beendet...");

        }
    }
    class Lager
    {
        static private int bestand;
        static object bestandLock = new();


        public static void Entnehmen()
        {
            Random r = new Random();
            //int menge = r.Next(1, 101);
            int menge = 50;
            while (bestand < menge)
            {
                //Console.WriteLine("Entnahme wartet...");
                Thread.Sleep(200);
            }
            lock (bestandLock)
            {
                bestand -= menge;
                if (bestand < 0)
                {
                    Console.WriteLine("Lager überleer!");
                }
            }

            Console.WriteLine($"Es wurden {menge} Teile aus dem Bestand entnommen...");
        }

        public static void Produzieren()
        {
            Random r = new Random();
            //int menge = r.Next(1, 101);
            int menge = 50;
            while (bestand >= 10000)
            {
                //Console.WriteLine("Produzent wartet...");
                Thread.Sleep(200);
            }
            lock (bestandLock)
            {
                bestand += menge;
                if (bestand>10050)
                {
                    Console.WriteLine("Lager übervoll!");
                }
            }
            Console.WriteLine($"Es wurden {menge} Teile dem Bestand hinzugefügt...");

        }
    }
}