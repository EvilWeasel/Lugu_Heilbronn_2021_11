using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Text.Json;

namespace Lugu.Helper.DataGenerator
{


    public enum Geschlecht { Weiblich=0, Männlich=1, Divers=2 }
    public class Person
    {
        public Geschlecht Geschlecht { get; set; }
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public double Gehalt { get; set; }

        public XElement ToXml()
        {
            XElement xelem = new XElement("Person");
            Type t = typeof(Person);
            foreach (PropertyInfo pi in t.GetRuntimeProperties())
            {
                xelem.Add(new XAttribute(pi.Name, pi.GetValue(this)));
            }
            return xelem;
        }
        public override string ToString()
        {
            //      XmlSerializer
            // X => XElement
            //      XmlWriter
            // X => Reflection
            //      StringBuilder 
            return ToXml().ToString();
            //return @$"<Person Id=""{Id}"" Vorname="""" />";
        }
        public Person()
        {

        }
        public Person(int id, string vorname, string nachname, Geschlecht geschlecht, decimal gehalt)
        {
            Id = id;
            Vorname = vorname;
            Nachname = nachname;
            Geschlecht = geschlecht;
            Gehalt = (double)gehalt;
        }
    }

    public class PersonenGenerator
    {
        private static PersonenGenerator _instance;
        public static PersonenGenerator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PersonenGenerator();
                }
                return _instance;
            }
        }

        private List<string> vornamenMaennlich;
        private List<string> vornamenWeiblich;
        private List<string> vornamenDivers;
        private List<string> nachnamen;

        private List<Person> personenliste;


        private PersonenGenerator()
        {
            personenliste = new List<Person>();
            nachnamen = new List<string>()
            { "Müller", "Schmidt", "Schneider", "Fischer", "Meyer",
            "Weber", "Hofmann", "Wagner", "Becker", "Schulz", "Schäfer", "Koch", "Bauer", "Richter", "Klein"};
            vornamenMaennlich = new List<string>();
            vornamenWeiblich = new List<string>();
            /*
             Marie,279,w
             Sophie,207,w
             Maria,174,w
             Maximilian,163,m
             Paul,145,m
             */

            using (StreamReader reader = new StreamReader("Vornamen_Koeln_2013.csv"))
            {
                reader.ReadLine(); // Überschrift
                while (!reader.EndOfStream)
                {
                    string vorname = reader.ReadLine();
                    string[] felder = vorname.Split(',');
                    int.TryParse(felder[1], out int anz);
                    if (anz > 1)
                    {
                        if (felder[2] == "w")
                            vornamenWeiblich.Add(felder[0]);
                        else
                            vornamenMaennlich.Add(felder[0]);
                    }
                }
            }
            vornamenDivers = vornamenMaennlich.Union(vornamenWeiblich).ToList();
            Debug.WriteLine("#Vornamen Männlich: " + vornamenMaennlich.Count);
            Debug.WriteLine("#Vornamen Weiblich: " + vornamenWeiblich.Count);
            Debug.WriteLine("#Vornamen Divers: " + vornamenDivers.Count);
            Debug.WriteLine("#Nachname: " + nachnamen.Count);

        }

        

        public void Clear()
        {
            personenliste.Clear();
        }

        public void Generate(int n)
        {
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                Person p = new Person();
                // Daten setzen
                // LINQ
                if (personenliste.Count == 0)
                    p.Id = 1;
                else
                    p.Id = personenliste.Max(x => x.Id) + 1;
                // ZUFALL: 49% Frauen 49% Männer 2% Divers 
                int z = rnd.Next(1, 101);
                if (z <= 49)
                {
                    p.Geschlecht = Geschlecht.Männlich;
                    p.Vorname = vornamenMaennlich[rnd.Next(vornamenMaennlich.Count)];
                }
                else if (z <= 98)
                {
                    p.Geschlecht = Geschlecht.Weiblich;
                    p.Vorname = vornamenWeiblich[rnd.Next(vornamenWeiblich.Count)];
                }
                else
                {
                    p.Geschlecht = Geschlecht.Divers;
                    p.Vorname = vornamenDivers[rnd.Next(vornamenDivers.Count)];
                }
                p.Nachname = nachnamen[rnd.Next(nachnamen.Count)];

                // 1000 ... 12000
                p.Gehalt = rnd.Next(1000, 12001);
                // 
                int rng = rnd.Next(10 * 365, 85 * 365);
                p.Geburtsdatum = DateTime.Today.AddDays(-rng);


                personenliste.Add(p);
            }
        }

        public IEnumerable<Person> GetPersonen()
        {
            foreach (Person p in personenliste)
            {
                yield return p;
            }
        }

        public void Load(string fn, bool append = false)
        {
            List<Person> newP = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText(fn));
            if (!append)
                personenliste.Clear();
            personenliste.AddRange(newP);
        }

        public void Save(string fn)
        {
            File.WriteAllText(fn, JsonSerializer.Serialize(personenliste));
        }





    }
}
