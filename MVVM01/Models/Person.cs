using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM01.Models
{
    public enum Anrede { Frau, Herr, Divers }

    public class Person
    {

        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Anrede Anrede { get; set; }
        public DateTime Geburt { get; set; }
        public decimal Gehalt { get; set; }
   
        public Person()
        {

        }

        public Person(string vorname,
            string nachname,
            Anrede anrede,
            DateTime geburt,
            string gehalt)
        {
             
             Vorname = vorname;
            Nachname = nachname;
            Anrede = anrede;
            Geburt = geburt;
            bool ok =decimal.TryParse(gehalt, out decimal g);
            Gehalt = g;
        }
       
    }

}
