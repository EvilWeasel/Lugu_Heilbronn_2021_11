using System;
using System.Collections.Generic;

namespace Delegaten05_Uebung
{
    interface IRun
    {
        void Run();
    }
    class Aufgabe1 : IRun
    {
        delegate int MyFunc(int a, int b);

        public void Run()
        {
            Console.WriteLine("*** Aufgabe 1 ***");
        }
    }
    class Aufgabe5 : IRun
    {
        // f(x)  => x² - 2
        // f'(x) => 2 * x 
        
        void Newton(Func<double,double> fn, Func<double,double> fab)
        {
            double xalt = 3;
            double xneu;
            while (true)
            {
                xneu = xalt - fn(xalt) / fab(xalt);
                if (Math.Abs(xneu - xalt) < 0.0001) break;
                xalt = xneu;
            }
            Console.WriteLine("NULLSTELLE: " + xneu);
        }

        public void Run()
        {
            Console.WriteLine("*** Aufgabe 5 ***");
            Newton(x => x * x  - 3, x => 2 * x);
        }
    }
    class Aufgabe2 : IRun
    {
        delegate decimal Op(decimal a);
        public void Run()
        {
            List<Op> ops = new List<Op>()
            {
                x=>x,
                x=>(decimal)Math.Sin((double)x),
                x=>(decimal)Math.Cos((double)x),
                x=>(decimal)Math.Tan((double)x),
                x=> x*x
            };
            // string.Format("{0:0.00} {1:dd.MM.yyyy} {2,10}, {3,-10}");
            Console.WriteLine("*** Aufgabe 2 ***");
            for(int i = 0; i<=20; i++)
            {
                Console.Write("| ");
                foreach(Op op in ops)
                {
                    string s = $"{ op(i / 10.0M):0.00}";
                    int n = (10 - s.Length) / 2;
                    s = new string(' ',n) + s + new string(' ',n);
                    Console.Write($"{s} | ");
                }
                Console.WriteLine();
            }
        }
    }

    class Aufgabe3: IRun
    {
        public void Run()
        {
            Console.WriteLine("*** Aufgabe 3 ***");
            Func<double, double, double, double> sum = (a, b, c) => a + b + c;

            Func<int, int, int, bool> checker = (a, c, b) => a >= c && c <= b;

        }
    }
    class Aufgabe4 : IRun
    {
        double Eval(Func<double,double> f, double x)
        {
            return f(x);
        }

        void EvalAndPrint(Func<double, double> f, double x)
        {
            Console.WriteLine($"RESULT for {x}:  {f(x)}");
        }

        public void Run()
        {
            Console.WriteLine("*** Aufgabe 4 ***");
            double result = Eval(x => x * x, 10);
            Console.WriteLine("RESULT: " + result);
            Console.WriteLine("RESULT: " + Eval(y => Math.Sqrt(y), 15));
            double result2 = ((Func<double, double>)(x => x * x))(20); //.Invoke(20);
            EvalAndPrint(x => x * x, 100);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IRun[] runner = new IRun[5];
            runner[0] = new Aufgabe1();
            runner[1] = new Aufgabe2();
            runner[2] = new Aufgabe3();
            runner[3] = new Aufgabe4();
            runner[4] = new Aufgabe5();
            foreach(var r in runner)
            {
                r.Run();
            }
        }
    }
}
