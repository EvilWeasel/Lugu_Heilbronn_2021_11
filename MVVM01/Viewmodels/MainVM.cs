using MVVM01.Helper;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM01.Viewmodels
{
    class MainVM : ViewModelBase
    {
        public PersonCollectionVM pvm { get; set; }
        private void SetView(string view)
        {
            HelpViewVisible = false;
            PersonCollectionVisible = false;
            PersonNewVisible = false;// Visibility.Collapsed;
            switch (view)
            {
                case "Help":
                    HelpViewVisible = true;
                    break;
                case "PersonCollection":
                    PersonCollectionVisible = true;
                    
                    break;
                case "PersonNew":
                    PersonNewVisible = true; //Visibility.Visible;
                    break;
            }
        }
        public MainVM()
        {
            SetViewCommand = new RelayCommand(
                (o) => {
                   SetView(o as string);
                   // SetView("PersonNew");
                },
                (o) => true);
            CloseCommand = new RelayCommand(
                (o) => {
                    Application.Current.MainWindow.Close();
                },
                (o) => true
                );
            SetView("Help");
        }

        private bool _helpViewVisible;
        public bool HelpViewVisible {
            get { return _helpViewVisible; }
            set {
                _helpViewVisible = value;
                RaisePropertyChanged(nameof(HelpViewVisible));
            } 
        }

        private bool _personNewVisible;
        public bool PersonNewVisible
        {
            get { return _personNewVisible; }
            set { 
                _personNewVisible = value;
                RaisePropertyChanged(nameof(PersonNewVisible));
            }
        }

        private bool _personCollectionVisible;
        public bool PersonCollectionVisible
        {
            get { return _personCollectionVisible; }
            set
            {
                _personCollectionVisible = value;
                RaisePropertyChanged(nameof(PersonCollectionVisible));
            }
        }

        public RelayCommand SetViewCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
    }
}
