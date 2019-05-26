using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppMVVM
{
    public class RelayCommand : ICommand
    {
        //#region ICommand Members

        //private Action WhattoExecute;
        //private Func<bool> WhentoExecute;

        //public RelayCommand(Action what, Func<bool> when)
        //{
        //    WhattoExecute = what;
        //    WhentoExecute = when;
        //}

        //public bool CanExecute(object parameter)
        //{
        //    return WhentoExecute();
        //}

        //public event EventHandler CanExecuteChanged;

        //public void Execute(object parameter)
        //{
        //    WhattoExecute();
        //}

        //#endregion

        Action<object> _execute;
        Func<object, bool> _canExecute;
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;

        }


        Action _executeMethod;
        Func<bool> _canExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            _executeMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute(parameter);
            }

            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod();
            }

            if (_executeMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects that get hooked up to command

        // Prism commands solve this in their implementation 
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            _executeMethod?.Invoke();
            _execute?.Invoke(parameter);
        }
    }

    //public class RelayCommand : ICommand
    //{

    //    Action<object> _execute;
    //    Func<object, bool> _canExecute;
    //    public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
    //    {
    //        _execute = execute;
    //        _canExecute = canExecute;

    //    }
    //    public bool CanExecute(object parameter)
    //    {
    //        if (_canExecute != null)
    //        {
    //            return _canExecute(parameter);
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }

    //    public event EventHandler CanExecuteChanged
    //    {
    //        add { CommandManager.RequerySuggested += value; }
    //        remove { CommandManager.RequerySuggested -= value; }
    //    }

    //    public void Execute(object parameter)
    //    {
    //        _execute(parameter);
    //    }

    //    bool ICommand.CanExecute(object parameter)
    //    {

    //        if (_canExecute != null)
    //        {
    //            return _canExecute(EventArgs.Empty);
    //        }

    //        if (_execute != null)
    //        {
    //            return true;
    //        }

    //        return false;
    //    }

    //    //public void RaiseCanExecuteChanged()
    //    //{
    //    //    CanExecuteChanged(this, EventArgs.Empty);
    //    //}

    //    //  // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects that get hooked up to command

    //    // Prism commands solve this in their implementation 
    //    //public event EventHandler CanExecuteChanged = delegate { };

    //    //void ICommand.Execute(object parameter)
    //    //{
    //    //    _execute?.Invoke();
    //    //}
    //}
}
