using MVVM01.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM01.Viewmodels
{
    class PersonCollectionVM : ViewModelBase
    {
        public ObservableCollection<Person> Personen { get; set; }

        public PersonCollectionVM()
        {
            Personen = new ObservableCollection<Person>(Personenliste.Instance.GetPersonen());
            Personenliste.Instance.Added += Instance_Added;
            Personen.CollectionChanged += Personen_CollectionChanged;
        }

        private void Personen_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    (e.NewItems[0] as Person).Gehalt = 350_000;
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;

            }
        }

        private void Instance_Added(Personenliste arg1, Person arg2)
        {
            Personen.Add(arg2);
        }
    }
}
