using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegaten02
{
    // Funktions-Typ
    // void x void  oder void => void
    delegate void Proz();

    // int x int => int oder int x int x int
    delegate int Op(int a, int b);

    delegate bool MyPredicate<T>(T a);
    delegate int MyComparison<T>(T a, T b);

    static class MyExtension
    {
        // Erweiterungs-Methode
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> l, Predicate<T> pred)
        {
            foreach (T elem in l)
            {
                if (pred(elem))
                    yield return elem;
            }
        }
    }

    class Program
    {
        static void P1()
        {
            Console.WriteLine("P1");
        }
        static void P2()
        {
            Console.WriteLine("P2");
        }

        //static IEnumerable<T> MyWhere<T>(List<T> l, Predicate<T> pred)
        //{
        //    foreach (T elem in l)
        //    {
        //        if (pred(elem))
        //            yield return elem;
        //    }
        //}

        static void WriteIf<T>(List<T> l, MyPredicate<T> pred)
        {
            foreach (T elem in l)
            {
                if (pred(elem))
                    Console.WriteLine(elem);
            }
        }
        
        static void Test5()
        {
            List<int> liste = new List<int>() { 1, 3, 5, 3, 4, 3, 1, 5, 7, 10, 6, 7 };
            WriteIf(liste, (x) => x >= 5 );

            //var x1 = MyExtension.MyWhere(liste, (x) => x >= 5);
            var x1 = liste.MyWhere(x => x >= 5); // EIGENES LINQ
            var x2 = x1.Where(x => x <= 7).Distinct().OrderBy(x=>x); // LINQ

            Console.WriteLine(string.Join(", ", x2));

        }


        static void Nmal(int n, Proz p, Predicate<int> pred)
        {
            for (int i = 0; i < n; i++)
            {
                if(pred(i))
                    p();
            }
        }

        static void Test4()
        {
            Nmal(10, () => Console.WriteLine("Hallo Welt"), (x)=> x%2==0 );
            Nmal(100, () => Console.Write("*") , x=> x==10);
            // Nmal(5, Test4);
        }

        static void Test3()
        {
            // delegate int Op(int a, int b);
            //Op opAdd = (aaa,bbb) => aaa + bbb;
            //Op opMul = (aaa,bbb) => aaa * bbb;
            Op o = (a, b) => (int)42.0;
            
            Op[] ops = {
                (aaa, bbb) => aaa + bbb,
                (aaa, bbb) => aaa - bbb,
                (aaa, bbb) => aaa / bbb,
                (aaa, bbb) => aaa * bbb
            };

            Dictionary<string, Op> ops2 = new Dictionary<string, Op> {
               {"+", (aaa, bbb) => aaa + bbb },
               {"-", (aaa, bbb) => aaa - bbb },
               {"/", (aaa, bbb) => {
                   if(bbb != 0)
                       return aaa / bbb;
                   else
                       return 42;
               }},
               {"*", (aaa, bbb) => aaa * bbb },
               {"MOD", (a,b) => a % b }
            };
            while (true)
            {
                Console.Write("Zahl eingeben: ");
                int.TryParse(Console.ReadLine(), out int x);
                Console.Write("Zahl eingeben: ");
                int.TryParse(Console.ReadLine(), out int y);
                Console.Write($"Operator ? ({ string.Join(", ", ops2.Keys)}): ");
                string op = Console.ReadLine();
                if (ops2.ContainsKey(op))
                {
                    Console.WriteLine($" {x} {op} {y} => {ops2[op](x,y)}");
                }
                else
                {
                    Console.WriteLine("Falscher Operator " + op);
                }
            }
        }


        static void Test2()
        {
            void A()
            {
                Console.WriteLine("A");
            }
            void B()
            {
                Console.WriteLine("B");
            }
            Proz C = () => Console.WriteLine("C");
            A();
            B();
            C();

            Console.WriteLine(new string('*', 60));

            List<Proz> todo = new List<Proz>() { A, B, C };
            todo.Add(() => Console.WriteLine("D"));
            todo.Add(() => Console.WriteLine("E"));
            foreach (Proz p in todo)
            {
                p();
            }

            //List<string> x = new List<string>();
            //// var x2 = x.Where(y => y.Length == 2);
            //// var x3 = x2.Select(y => y.ToUpper());

            //// var x4 = x3.ToList();

            //// var x5 = x.Where(y => y.Length == 2).
            ////            Select(y => y.ToUpper()).
            ////            ToList();

            //var x5 = (from y in x
            //          where y.Length == 2
            //          select y.ToUpper()).ToList();

        }


        static void Test1()
        {
            int a = 10; // Datentyp: int, Variable: a, Objekt: 10
            string p = new string("ABC"); // Datentyp: string, Variable p, Objekt: "ABC"
            Proz proz = new Proz(P1); // Datentyp: Proz, Variable: proz, Objekt: P1
            // Call, Aufruf
            proz();
            proz = P2;
            proz();
            // Funktions-Literal
            // VAR = LAMBA
            // LAMBDA  (p1,p2) => {ANWEISUNGEN}
            //         ()      => {ANWEISUNGEN}

            proz = () => Console.WriteLine("LAMBDA");
            proz();

            /* MyPredicate<string> mp = (s) => s.Length == 4;
             MyComparison<string> mc = (s1, s2) =>
             {
                 if (s1.Length > s2.Length) return 1;
                 else if (s1.Length < s2.Length) return -1;
                 else return 0;
             };

             List<string> x = new List<string>();
             x.FindAll(  (s) => s.Length == 4 );
             x.Sort((s1, s2) => 42 );*/

        }

        static void Main(string[] args)
        {
            Test5();
        }
    }
}
