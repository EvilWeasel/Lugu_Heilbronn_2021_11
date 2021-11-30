using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM01.Helper
{
    // delegate void RelayExec(object o);
    // delegate bool RelayCanExec(object o);
    // delegate void Action();
    // delegate void Action<T1>(T1 o);
    // delegate void Action<T1, T2>(T1 t1, T2 t2);
    // delegate TR Func<T1,T2,TR>(T1 t1, T2 t2);
    // delegate TR Func<T1,TR>(T1 t1);

    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> exec;
        private Func<object, bool> canexec;

        public RelayCommand(Action<object> e, 
            Func<object,bool> ce = null)
        {
            exec = e;
            canexec = ce;
        }

        public bool CanExecute(object parameter)
        {
            if (canexec != null)
                return canexec(parameter);
            else
                return false;
        }

        public void Execute(object parameter)
        {
           // if(exec != null)
           //     exec(parameter);
          exec?.Invoke(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
