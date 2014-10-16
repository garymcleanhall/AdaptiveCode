using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AsyncDecorator
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> execute) :
            this(execute, _ => true)
        {

        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if(CanExecute(parameter))
            {
                execute(parameter);
            }
        }

        private Predicate<object> canExecute;
        private Action<object> execute;
    }
}
