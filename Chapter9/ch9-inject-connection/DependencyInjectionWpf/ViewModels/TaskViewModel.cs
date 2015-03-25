using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                if(id != value)
                {
                    id = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ID"));
                }
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if(description != value)
                {
                    description = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Description"));
                }
            }
        }

        public string Priority
        {
            get
            {
                return priority;
            }
            set
            {
                if(priority != value)
                {
                    priority = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Priority"));
                }
            }
        }

        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                if (dueDate != value)
                {
                    dueDate = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("DueDate"));
                }
            }
        }

        public bool Completed
        {
            get
            {
                return completed;
            }
            set
            {
                if(completed != value)
                {
                    completed = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Completed"));
                }
            }
        }
      
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private int id;
        private DateTime dueDate;
        private string description;
        private string priority;
        private bool completed;
    }
}
