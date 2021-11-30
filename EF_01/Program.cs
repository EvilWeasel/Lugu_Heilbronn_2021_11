using Lugu.Helper.DataGenerator;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Utilities;

namespace EF_01
{
    class Program
    {



        // Code-First
        // Modell-First
        // Database-First

        static void Query03()
        {
            using(MAContext ctx = new())
            {
                ctx.Abteilungsliste.Load();
                ctx.Mitarbeiterliste.Load();
                foreach (Mitarbeiter m in ctx.Mitarbeiterliste.Include("Abteilung"))
                {
                    Console.WriteLine($"-- {m.Vorname} {m.Nachname}");
                    Console.WriteLine("\t--- Kollegen ---");
                    //foreach (Mitarbeiter k in m.Abteilung.Mitarbeiterliste)
                    //{
                    //    Console.WriteLine();
                    //}
                    string k = string.Join(", ", m.Abteilung.Mitarbeiterliste.Select(x=> x.Vorname + " " + x.Nachname).Where(x=> x != m.Vorname + " " + m.Nachname));
                    Console.WriteLine($"\t> {k}");
                }
                ctx.SaveChanges();
            }
        }


        static void Query01()
        {
            using(MAContext ctx = new())
            {
                // Nachladen von abhängigen Daten mit INCLUDE => EAGER LOADING
                //                                       LOAD => EXPLIZITES LADEN
                foreach (Mitarbeiter m in ctx.Mitarbeiterliste.Include("Abteilung").OrderBy(x=>x.Gehalt))
                {
                    Console.WriteLine($"Mitarbeiter: {m.Vorname} {m.Nachname}");
                    Console.WriteLine($"\t- Abteilung: {(m.Abteilung == null ? "Arbeitslos" : m.Abteilung.Name)}");
                    Console.WriteLine($"\t- Gehalt: {m.Gehalt}");
                }
            }
        }
        static void Query02()
        {
            
            using (MAContext ctx = new())
            {
                // Nachladen von abhängigen Daten mit INCLUDE => EXPLIZITES LADEN
                foreach (Mitarbeiter m in ctx.Mitarbeiterliste.Include("Abteilung").OrderBy(x => x.Gehalt))
                {
                    Console.WriteLine($"Mitarbeiter: {m.Vorname} {m.Nachname}");
                    Console.WriteLine($"\t- Abteilung: {(m.Abteilung == null ? "Arbeitslos" : m.Abteilung.Name)}");
                    Console.WriteLine($"\t- Gehalt: {m.Gehalt}");
                }
            }
        }


        static void InsertMitarbeiter(int n)
        {
            PersonenGenerator.Instance.Generate(n);
            Mitarbeiter m;
            Random r = new();
            using (MAContext ctx = new())
            {

                foreach (Person p in PersonenGenerator.Instance.GetPersonen())
                {
                    m = new Mitarbeiter();
                    m.Geburt = p.Geburtsdatum;
                    m.Vorname = p.Vorname;
                    m.Nachname = p.Nachname;
                    m.Gehalt = (decimal)p.Gehalt;
                    int index = r.Next(ABTEILUNGEN.Length);
                    string abtname = ABTEILUNGEN[index];

                    // LINQ TO ENTITIES 
                    m.Abteilung = ctx.Abteilungsliste.FirstOrDefault(x => x.Name == abtname);

                    ctx.Mitarbeiterliste.Add(m);
                }
                ctx.SaveChanges();

            }


        }

        static void DeleteAbteilungen()
        {
            using (MAContext ctx = new())
            {
                Console.WriteLine("Delete Abteilungen...");
                foreach (Abteilung a in ctx.Abteilungsliste.Include("Mitarbeiterliste"))
                {
                    Console.WriteLine("# Mitarbeiter: " + a.Mitarbeiterliste.Count);
                    foreach (Mitarbeiter m in a.Mitarbeiterliste)
                    {
                        Console.WriteLine("Reset Mitarbeiter " + m.Nachname);
                        m.Abteilung = null;
                    }
                    ctx.Abteilungsliste.Remove(a);
                }
                ctx.SaveChanges();
                Console.WriteLine("OK");
            }
        }

        static string[] ABTEILUNGEN = { "IT", "Einkauf", "Verkauf", "Marketing", "Security", "Produktion" };
        static void CreateAbteilungen()
        {
            Console.WriteLine("Creating Abteilungen...");
            using (MAContext ctx = new())
            {
                foreach (string s in ABTEILUNGEN)
                {
                    ctx.Abteilungsliste.Add(new Abteilung() { Name = s });
                }
                ctx.SaveChanges();
                Console.WriteLine("OK");
            }
        }



        /// <summary>
        /// Schreiben Test 01
        /// </summary>
        static void Test01()
        {
            using (MAContext ctx = new())
            {
                Abteilung a = new() { Id = 0, Name = "IT" };
                ctx.Abteilungsliste.Add(a);
                Mitarbeiter m = new() { Id = 1, Vorname = "Max", Nachname = "Mustermann", Gehalt = 4000, Geburt = DateTime.Now };
                a.Mitarbeiterliste.Add(m);



                ctx.SaveChanges();
                Console.WriteLine("OK");
            }
        }

        static void Main(string[] args)
        {
            //Test01();
            //DeleteAbteilungen();
            //CreateAbteilungen();
            //InsertMitarbeiter(100);
            //Query01();
            //Query02();
            Query03();
        }
    }


}