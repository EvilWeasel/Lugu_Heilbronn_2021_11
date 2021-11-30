using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bibliothek_Wetterdaten;

namespace Uebung_Wetterdaten
{
    class Program
    {
        static List<Wetterdaten> Wetter;
        static void Aufgaben_01()
        {
            var a1 = Wetter.
                Where(x => x.Jahr >= 2000 && x.Jahr <= 2099 && x.TMax > 23).
                Select(x => new { x.Jahr, x.Monat, x.Rain });
            foreach(var elem in a1)
            {
                Console.WriteLine(elem);
            }

        }
        static void Main(string[] args)
        {
            Wetter = Wetterdaten_Verwaltung.Lesen("wetterdaten.csv");
            Aufgaben_01();
            Console.ReadKey();
        }
    }
}
