using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM01.Helper;
using MVVM01.Models;

namespace MVVM01.Viewmodels
{
    class PersonNewVM : ViewModelBase
    {
        // ObservableCollection
        public ObservableCollection<string> Anredenliste { get; set; }

        private int _anredeindex;

        public int AnredeIndex
        {
            get { return _anredeindex; }
            set
            {
                _anredeindex = value;
                RaisePropertyChanged("AnredeIndex");
            }
        }

        private string _vorname;
        public string Vorname
        {
            get { return _vorname; }
            set
            {
                _vorname = value;
                RaisePropertyChanged("Vorname");
            }
        }

        private string _nachname;
        public string Nachname
        {
            get { return _nachname; }
            set
            {
                _nachname = value;
                RaisePropertyChanged("Nachname");
            }
        }

        private DateTime _geburtsdatum;
        public DateTime Geburtsdatum
        {
            get { return _geburtsdatum; }
            set
            {
                _geburtsdatum = value;
                RaisePropertyChanged("Geburtsdatum");
            }
        }

        private string _gehalt;
        public string Gehalt
        {
            get { return _gehalt; }
            set
            {
                _gehalt = value;
                RaisePropertyChanged("Gehalt");
            }
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        private void ResetData()
        {
            Vorname = "Klaus";
            Nachname = "Mustermann";
            AnredeIndex = (int)Anrede.Herr;
            Geburtsdatum = DateTime.Now.AddDays(-8000);
            Gehalt = "2000";
        }
        public PersonNewVM()
        {
            Anredenliste = new ObservableCollection<string>(Enum.GetNames(typeof(Anrede)));
            ResetData();

            SaveCommand = new RelayCommand(
                (o) =>
                {
                    Person p = new Person(Vorname,
                        Nachname,
                        (Anrede)AnredeIndex,
                        Geburtsdatum,
                        Gehalt);

                    Personenliste.Instance.AddPerson(p); 
                    
                    ResetData();
                },
                (o) => true);
            ResetCommand = new RelayCommand(
                (o) =>
                {
                    ResetData();
                },
                (o) => true);
        }

    }
}
