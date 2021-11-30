


async Task<int> Calc01()
{
    await Task.Delay(3000);
    return 42;
}

async Task MachWas(char c)
{
    for (int i = 0; i < 100; i++)
    {
        await Task.Delay(10);
        Console.Write(c);
    }
}

//_ = MachWas('A');

Task t4 = Task.Run(() =>
{
    for (int i = 0; i < 100; i++)
    {
        Thread.Sleep(20);
        //Task.Delay(10);
        Console.Write("C");
    }
});

Task<int> t0 = Calc01();
t0.GetAwaiter().OnCompleted(() => Console.WriteLine("Antwort: "));
Task t1 = MachWas('A');

Task t2 = MachWas('B');
Task.Delay(500).GetAwaiter().OnCompleted(() => Console.WriteLine("500ms"));


Task.WaitAll(t0, t1, t2, t4);
Console.WriteLine("Hello World!");




//Console.ReadKey();