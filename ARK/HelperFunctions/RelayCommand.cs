﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ARK.HelperFunctions
{
    /// <summary>
    /// Implementation of the ICommand interface
    /// </summary>
    /// <remarks>
    /// This implementation of RelayCommand was created by Josh Smith http://msdn.microsoft.com/en-us/magazine/dd419663.aspx
    /// </remarks>
    public class RelayCommand : ICommand 
    { 
        readonly Action<object> _execute; 
        readonly Predicate<object> _canExecute; 

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute"); 
            _execute = execute; 
            _canExecute = canExecute; 
        }

        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        } 
        
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; } 
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
