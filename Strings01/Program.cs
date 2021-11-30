using System;
using System.Diagnostics;
using System.Text;

namespace Strings01
{
    class Program
    {
        static void StringTest3(int n)
        {
            //char[] s = new char[n];
            StringBuilder s = new StringBuilder(16);
            Stopwatch uhr = new Stopwatch();

            uhr.Start();
            for (int i = 0; i < n; i++)
            {
                s.Append('.');
            }
            uhr.Stop();
            Console.WriteLine($"StringTest ({n}): {uhr.ElapsedMilliseconds} ms");
            // Array Of Char => String
            string newstring = s.ToString();

            // newstring[10] = 'x'; // String ist nicht veränderbar!!!
            Console.WriteLine("LENGTH: " + newstring.Length);
            // Console.WriteLine(newstring);
        }

        static void StringTest2(int n)
        {
            char[] s = new char[n];
            Stopwatch uhr = new Stopwatch();
             
            uhr.Start();
            for (int i = 0; i < n; i++)
            {
                s[i] = '.';
            }
            uhr.Stop();
            Console.WriteLine($"StringTest ({n}): {uhr.ElapsedMilliseconds} ms");
            // Array Of Char => String
            string newstring = new string(s);

            // newstring[10] = 'x'; // String ist nicht veränderbar!!!
            Console.WriteLine("LENGTH: " + newstring.Length);
            // Console.WriteLine(newstring);
        }

        static void StringTest(int n)
        {
            Stopwatch uhr = new Stopwatch();
            string s = "";

            uhr.Start();
            for (int i = 0; i < n; i++)
            {
                s += ".";
            }
            uhr.Stop();
            Console.WriteLine($"StringTest ({n}): {uhr.ElapsedMilliseconds} ms");
        }

        static void Main(string[] args)
        {
            //StringTest(50_000);
            StringTest(100_000);
            //StringTest(200_000);
            StringTest2(10_000_000);
            StringTest3(10_000_000);

        }
    }
}
