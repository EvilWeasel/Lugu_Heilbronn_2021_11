using System;
using System.Reflection;
using System.Linq;

namespace Reflections_Uebung
{

    class Person
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public double Gehalt { get; set; }

        public Person Clone()
        {
            // Mit Reflection 
            // Schleife über die Properties
            Person cpy = new Person();
           
            Type t = GetType(); //typeof(Person);
            foreach (PropertyInfo pi in t.GetRuntimeProperties())
            {
                object val = pi.GetValue(this);
                pi.SetValue(cpy, val);
            }
            return cpy;
        }

        public override string ToString()
        {
            return string.Join(", " , GetType().GetRuntimeProperties().Select(s=> s.GetValue(this)));
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person()
            {
                Id = 1,
                Gehalt = 2000,
                Nachname = "Nickel",
                Vorname = "Norbert",
                Geburtsdatum = DateTime.Now.AddYears(-42)
            };
            Person clone = p.Clone();
            Console.WriteLine(clone);
        }
    }
}
