using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Person
    {
        public int Id { get; set; }
        public string Nachname { get; set; }
        public override string ToString()
        {
            return "PERSON : " + Id;
        }
    }
}
