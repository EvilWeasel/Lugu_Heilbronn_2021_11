using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM01.Models
{
    public class Personenliste
    {
        public event Action<Personenliste, Person> Added;
        private static object sema = new object();
        private static Personenliste instance;
        public static Personenliste Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (sema)
                    {
                        if (instance == null)
                        {
                            instance = new Personenliste();
                        }
                    }
                }
                return instance;
            }
        }
        private Personenliste()
        {
            pliste = new List<Person>();
        }
        private List<Person> pliste;

        public void AddPerson(Person p)
        {
            pliste.Add(p);
            Added?.Invoke(this, p); 
        }

        public IEnumerable<Person> GetPersonen()
        {
            foreach(Person p in pliste)
            {
                yield return p;
            }
        }

         
        public void Save()
        {
            throw new NotImplementedException();
        }
        public void Load()
        {
            throw new NotImplementedException();
        }
    }

}
