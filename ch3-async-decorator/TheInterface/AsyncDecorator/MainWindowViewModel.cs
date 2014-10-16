using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AsyncDecorator
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel(IComponent component)
        {
            this.component = component;
            calculateCommand = new RelayCommand(Calculate);
        }

        public string Result
        {
            get
            {
                return result;
            }
            private set
            {
                if (result != value)
                {
                    result = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Result"));
                }
            }
        }

        public ICommand CalculateCommand
        {
            get 
            {
                return calculateCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void Calculate(object parameter)
        {
            Result = "Processing...";
            component.Process();
            Result = "Finished!";
        }

        private string result;
        private IComponent component;
        private RelayCommand calculateCommand;
    }
}
