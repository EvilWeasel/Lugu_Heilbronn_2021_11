using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegaten04_Wiederholung
{
    // delegate
    // Funktionstyp - Methodentyp
    // Beschreibt eine Methode
    class MyEventArgs { }

    delegate void A();
    delegate int B(int a, int b);
    delegate void C(string x, A a);
    delegate void MyEventhandler(object sender, MyEventArgs args);
    class Program
    {
        static void Test02()
        {
            int MyCompare(string s1, string s2)
            {
                // return s1.CompareTo(s2);
                // s1 > s2 => return 1
                // s1 < s2 => return -1
                // s1 == s2 => return 0
                int max = s1.Length > s2.Length ? s2.Length : s1.Length;
                for (int i = 0; i < max; i++)
                {
                    if (s1[i] > s2[i]) return -1;
                    else if (s1[i] < s2[i]) return 1;
                }
                if (s1.Length == s2.Length)
                    return 0;
                else
                    return s2.Length - s1.Length;
            }

            string s = "";
            // s.CompareTo()
            
            List<string> l1 = new List<string>() { "Hans", "Dieter", "Horsti", "Bernd", "Karl-Otto" };

            l1.Sort(); // benutzt string.CompareTo(string other) zum Vergleichen
            Console.WriteLine("** SORT **");
            Console.WriteLine(string.Join(",",l1));
            // IComparer    <= Interface
            // Comparison   <= delegate
            // delegate int Comparison<T>(T a, T b)
            // Man muss dem Sort eine Compare-Methode übergeben
            l1.Sort(MyCompare);
            Console.WriteLine("** SORT 2 **");
            Console.WriteLine(string.Join(",", l1));

            l1.Sort((a, b) => b.Length - a.Length);
            Console.WriteLine("** SORT 3 **");
            Console.WriteLine(string.Join(",", l1));
            // Bubble-Sort? O(n²)            => 1024*1024          = 1_000_000
            // Quick-Sort?  O(1.4 * lgn * n) => 1.4 * 10 = 1024    =    14_000

        }

        static void Test01()
        {
            Action a1 = () => Console.WriteLine("A");
            A a2 = () => Console.WriteLine("A");
            A a3 = () => {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            };
            B b1 = (p1, p2) => p1 + p2 - 1; // return p1 + p2 -1
            B b2 = (p1, p2) =>
            {
                int x = p1;
                int y = p2;
                return x * y;
            };
            Func<int,int,int> b3 = (p1, p2) => p1 + p2 - 1;

            // b3 = (x,y) => b2(x,y);
            // b2 = b1;
            C c1  = (urgs, aargh) => aargh();
            Action<string, A> c2 = (p1, p2) => p2(); 

        }

        static void Main(string[] args)
        {
            Test02();
        }
    }
}
