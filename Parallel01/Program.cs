// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Diagnostics;

Parallel.For(1, 11, (x) => Console.WriteLine($"Number {x}"));

Console.WriteLine(new String('*', 80));


List<string> list0 = new() { "Bischoff", "Wehrle", "Nagel", "Schwenzer" };

Parallel.ForEach(list0, (x) => Console.WriteLine($"Mister {x}"));

Console.WriteLine(new String('*', 80));

Parallel.Invoke(() => Console.WriteLine("A"), () => Console.WriteLine("B"), () => Console.WriteLine("C"));

Console.WriteLine(new String('*', 80));

Console.WriteLine(42 + "=>" + (char)42);

Console.WriteLine(new String('*', 80));
Console.WriteLine(new String('*', 80));

//ThreadPool.SetMinThreads(3, 3);
var x = ThreadPool.GetMaxThreads;
Console.WriteLine("MaxThreads: " + x.ToString());
var y = ThreadPool.GetMinThreads;
Console.WriteLine("MinThreads: " + y.ToString());
var z = ThreadPool.GetAvailableThreads;
Console.WriteLine("AvailableThreads: " + z.ToString());


ThreadPool.SetMaxThreads(3, 3);


ThreadPool.SetMinThreads(3, 3);


for (int i = 65; i < 90; i++)
{
    ThreadPool.QueueUserWorkItem((o) =>
    {
        Console.WriteLine("\nThreadCount: " + ThreadPool.ThreadCount+"\n");
        char c = (char)o;
        for (int l = 0; l < 50; l++)
        {
            Thread.Sleep(4);
            Console.Write($"{l}{c}");
        }
    }, (char)i);


}
int workerThreads;
int portThreads;
ThreadPool.GetMaxThreads(out workerThreads, out portThreads);
Console.WriteLine("\nMaximum worker threads: \t{0}" +
    "\nMaximum completion port threads: {1}",
    workerThreads, portThreads);

ThreadPool.GetAvailableThreads(out workerThreads,
    out portThreads);
Console.WriteLine("\nAvailable worker threads: \t{0}" +
    "\nAvailable completion port threads: {1}\n",
    workerThreads, portThreads);


foreach (Process p in Process.GetProcesses())
{
    Console.WriteLine(p.ProcessName);
    
}

Process notepad = Process.Start(new ProcessStartInfo("Notepad.exe",@"c:\temp\test.txt"));
notepad.EnableRaisingEvents = true;
notepad.Exited += (s, e) => { Console.WriteLine("Notepad Fertig!"); };

Console.ReadKey();