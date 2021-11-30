using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates03
{
    class Program
    {
        delegate void Proz();

        static IEnumerable<T> Where<T>(IEnumerable<T> liste, Func<T,bool> pred)
        {
            foreach(T elem in liste)
            {
                if (pred(elem))
                    yield return elem;
            }
        }

        static IEnumerable<T2> Select<T, T2>(IEnumerable<T> liste, Func<T, T2> sel)
        {
            foreach (T elem in liste)
            {
               yield return sel(elem);
            }
        }

        static void Test01()
        {
            Action a = () => Console.WriteLine("TEST01");
            Action<string> b = (x) => Console.WriteLine("Länge von String: " + x.Length);
            Action<int, string> c;
            Action<double, double, double> d;

            // Func => letzter Datentyp ist der Rückgabe-Typ
            Func<int> f1 = () => 42;
            Func<int, bool> f2 = (x) => x % 2 == 0;

            List<string> l1 = new List<string>() { "A", "C", "AA", "BBB" };
            var erg = Where(l1, (s) => s.Length == 2);
            var erg2 = Select(l1, (s) => s.Length);
            // "A", "C", "AA", "BBB"   =>  1, 1, 2, 3
            var erg3 = Select(l1, (s) => "TEST: " + s);
            // "A", "C", "AA", "BBB"   =>  Test: A, Test: C, Test: AA, Test:BBB

            List<string> l2 = new List<string>() { "10.2", "11.1", "9.5", "10.4" };
            
            // Eigene Methode "Select"
            var erg4 = Select(l2, (s) => double.Parse(s.Replace(".",",")));
            // LINQ Methode "Select"
            var erg5 = l2.Select((s) => double.Parse(s.Replace(".", ",")));
            
            foreach(double val in erg4)
            {
                Console.WriteLine(val + "=>" + (val*2));
            }
        
        }


        static void Main(string[] args)
        {
            Test01(); 
        }
    }
}

// MVVM
// Model - ViewModel - View

//Events ...

