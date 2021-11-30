// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

// Synchronisiert Threads innerhalb einer gemeinsamen Methode

class Test01
{
    async Task T1(string s, int n, int delay = 20)
    {
        for (int i = 0; i < n; i++)
        {
            await Task.Delay(delay);
            Console.Write(s);
            bar1.SignalAndWait(100);
            Console.WriteLine();
        }
    }
    Barrier bar1 = new(3);
    public void Run()
    {

        Task t1 = T1("ABC", 20);
        Task t2 = T1("DEF", 10);
        Task t3 = T1("GHI", 15);
        Task.WaitAll(t1, t2, t3);
        //((Action)(() => Console.WriteLine("FERTIG")))();
        Console.WriteLine("FERTIG!!!");

    }



}

class Test02
{
    EventWaitHandle halloHandle = new(false, EventResetMode.ManualReset);
    EventWaitHandle weltHandle = new(false, EventResetMode.ManualReset);
    EventWaitHandle schwabenHandle = new(false, EventResetMode.ManualReset);


    async Task Hallo()
    {
        while (true)
        {
            halloHandle.WaitOne();
            await Task.Delay(15);
            Console.Write("Hallo");
            halloHandle.Reset();
            schwabenHandle.Set();

        }
    }

    async Task Welt()
    {
        while (true)
        {
            weltHandle.WaitOne();
            await Task.Delay(10);
            Console.WriteLine(" Welt");
            weltHandle.Reset();
            halloHandle.Set();


        }

    }
    async Task Schwaben()
    {
        while (true)
        {
            schwabenHandle.WaitOne();
            await Task.Delay(10);
            Console.Write(" Schwaben");
            schwabenHandle.Reset();
            weltHandle.Set();


        }

    }

    public void Run()
    {
        halloHandle.Set();
        _ = Hallo();
        _ = Schwaben();
        _ = Welt();


    }


}

class Program
{
    static void Main(string[] args)
    {
        Test02 t = new();
        t.Run();
        Console.ReadKey();
        Console.WriteLine("Fertig");
    }

}





