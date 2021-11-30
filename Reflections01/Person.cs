using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections01
{
    [XRename("Mitarbeiter")]
    class Person
    {
        public bool dummy;
        
        [XRename("Nr")]
        public int Id { get; set; }
        public string Vorname { get; set; }
        [XRename("Name")]
        public string Nachname { get; set; }
        
        private int alter;
        [XIgnore]
        public int Alter
        {
            get { return alter; }
            set { alter = value; }
        }
        public string GetName()
        {
            
            return Vorname + " " + Nachname;
        }
        public Person Clone()
        {
            /* Person p = new Person();
             p.Id = Id;
             p.Nachname = Nachname;
             p.Vorname = Vorname;
             p.Alter = alter;
             p.dummy = dummy;
             return p;*/
            return (Person)MemberwiseClone();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** Person ***");
            foreach(PropertyInfo pi in GetType().GetRuntimeProperties())
            {
                sb.AppendLine($"{pi.Name}: {pi.GetValue(this)}");
            }
            // sb.AppendLine("...........");
            // string res = string.Join(", ",GetType().GetRuntimeProperties().Select(p => p.Name + ": " + p.GetValue(this)));
            // sb.AppendLine(res);
            sb.AppendLine("***********");
            return sb.ToString();
        }
    }
}
