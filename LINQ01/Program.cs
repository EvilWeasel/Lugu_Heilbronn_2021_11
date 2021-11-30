using System;
using Lugu.Helper.DataGenerator;
using Lugu.Extensions;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.IO;

namespace LINQ01
{
    class Generator123 : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 100000; i++)
            {
                yield return 1;
                yield return 2;
                yield return 3;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    class Program
    {
        static void Test04()
        {
            Generator123 gen = new Generator123();

            //IEnumerator<int> it = gen.GetEnumerator();
            //while(it.MoveNext())
            //{
            //    Console.WriteLine(it.Current);
            //}

            var q1 = (from x in gen
                      select x).ToList();
            Console.WriteLine(q1.Count);
            foreach (int elem in gen)
            {

            }

        }
        static void Test03()
        {
            List<int> l1 = new List<int>() { 1, 2, 3 };
            IEnumerator<int> it1 = l1.GetEnumerator();

            bool gibtseinweiteres;
            gibtseinweiteres = it1.MoveNext();
            Console.WriteLine(it1.Current);
            gibtseinweiteres = it1.MoveNext();
            Console.WriteLine(it1.Current);
            gibtseinweiteres = it1.MoveNext();
            Console.WriteLine(it1.Current);

            //while(it1.MoveNext())
            // {
            //    Console.WriteLine(it1.Current);
            // }

        }

        static void Test05_Agg()
        {
            var basis = PersonenGenerator.Instance.GetPersonen();
            // SUM, AVG, MAX, MIN, COUNT
            var sumGehalt = basis.Sum(x => x.Gehalt);
            Console.WriteLine("SUMGEHALT: " + sumGehalt);
            var maxGehalt = basis.Max(x => x.Gehalt);
            Console.WriteLine("MAXGEHALT: " + maxGehalt);

            var bestVerdiener = basis.Where(x => x.Gehalt == basis.Max(y => y.Gehalt));
            bestVerdiener.Write("BESTVERDIENER");

            //PersonenGenerator.Instance.Clear();
            // Single(), SingleOrDefault
            var bestVerdiener2 = basis.OrderByDescending(x => x.Gehalt).FirstOrDefault(); // First()
            if (bestVerdiener2 != null)
                Console.WriteLine("BESTVERDIENER2: " + bestVerdiener2);
            else
                Console.WriteLine("KEINE PERSON IN DER LISTE!!!");

            var bestVerdiener3 = basis.OrderByDescending(x => x.Gehalt).Take(3); //.TakeWhile(x=>x.Gehalt==maxGehalt);
            bestVerdiener3.Write("BESTVERDIENER3: ");

            var nmbDivers = basis.Count(x => x.Geschlecht == Geschlecht.Divers);
            Console.WriteLine("#Divers:" + nmbDivers);

        }
        static void Test06()
        {
            var basis = PersonenGenerator.Instance.GetPersonen();
            var q1 = basis.Take(10);
            var q2 = basis.TakeWhile(x => x.Geschlecht == Geschlecht.Männlich);
            var q3 = basis.Skip(10);




            for (int i = 0; i < basis.Count() / 10; i++)
            {
                Console.Clear();
                Console.WriteLine($"SEITE {i + 1}");
                var q4 = basis.Skip(i * 10).Take(10);
                q4.Write();
                Console.WriteLine("WEITER MIT TASTE");
                Console.ReadKey();
            }

            var q5 = basis.Take(10).Skip(10).Take(3);
            q5.Write();


        }


        static void Test07_Group()
        {
            var basis = PersonenGenerator.Instance.GetPersonen();

            // Personen nach Nachnamen gruppiert
            var nn = basis.GroupBy(x => x.Nachname);
            // nn.Write();
            string gr = "";
            double max = 0.0;
            foreach (var group in nn)
            {
                Console.WriteLine("Gruppe: " + group.Key);
                group.Write();
                // Maximaler Verdienst pro Nachname
                Console.WriteLine("MAX VERDIENST:" +
                        group.Max(y => y.Gehalt));

                if (max <= group.Max(y => y.Gehalt))
                {
                    max = group.Max(y => y.Gehalt);
                    gr = group.Key;
                }
            }
            Console.WriteLine("GRUPPE MAX: " + gr);
        }



        static void Test02()
        {

            // Ausdruck
            IEnumerable<Person> q1 = (from p in PersonenGenerator.Instance.GetPersonen()
                                      where p.Gehalt > 10_000.0
                                      select p);

            var q1b = PersonenGenerator.Instance.GetPersonen().Where(p => p.Gehalt > 10000);

            // PersonenGenerator.Instance.Clear();
            q1.Write("*** Gehalt > 10000 ***");
            // Console.WriteLine(q1.First());

            var basis = PersonenGenerator.Instance.GetPersonen();
            var q2 = basis.Where(x => x.Id < 50).Select(x => x.Id);
            q2.Write("*** Nur Ids ***");
            var q3 = basis.
                           OrderByDescending(x => x.Geburtsdatum).
                           Select(x => $"{x.Nachname} {x.Vorname} ({x.Geburtsdatum:yyyy-MM-dd})");

            var q3b = from x in basis
                      orderby x.Geburtsdatum descending
                      select $"{x.Nachname} {x.Vorname} ({x.Geburtsdatum:yyyy-MM-dd})";

            q3b.Write("*** NN VN GEB als string");

            //var px = new { Vorname = "Max", Nachname = "Mustermann" };
            //Console.WriteLine(px);
            //Console.WriteLine("TypName:" + px.GetType().Name);
            //Console.WriteLine(px.Nachname);
            //Console.WriteLine(px.Vorname);

            var q4 = from x in basis
                     select new { VN = x.Vorname, NN = x.Nachname, G = x.Gehalt, G12 = x.Gehalt * 12 };

            /*var q4b = from x in basis
                      select Tuple.Create(x.Vorname, x.Nachname, x.Gehalt);

            var q4c = from x in basis
                      select (x.Vorname, x.Nachname, x.Gehalt);*/

            /*var px = (1, 2, 3);

            int a, b, c;
            (a, b, c) = px;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);*/
            var q4d = basis.Select(x => new { x.Vorname, x.Nachname, x.Gehalt });

            q4d.Write();

            var q5 = basis.Select(x => x.Nachname).Distinct().OrderBy(x => x);
            q5.Write();

        }

        static void Test01()
        {
            Console.WriteLine("**** Alle Personen ****");
            foreach (Person p in PersonenGenerator.Instance.GetPersonen())
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("-----------------------");
        }
        
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static string fn = Path.Combine(path, "personen.json");

        static void Test_Save ()
        {
            PersonenGenerator.Instance.Generate(100);
            PersonenGenerator.Instance.Save(fn);
        }
        static void Show_File()
        {
            Console.WriteLine(File.ReadAllText(fn));
        }
        static void Test_Load()
        {
            PersonenGenerator.Instance.Load(fn);
            PersonenGenerator.Instance.Load(fn,true);
        }
        static void Main(string[] args)
        {
            //Test_Save();
            //Show_File();
            Test_Load();
            //Test07_Group();
            Test02();
        }
    }
}
