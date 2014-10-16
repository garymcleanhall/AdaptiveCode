using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

using Microsoft.Practices.ServiceLocation;

using ServiceInterfaces;
using ViewModels;

namespace Controllers
{
    public class TaskListController : INotifyPropertyChanged
    {
        public void OnLoad()
        {
            var taskService = ServiceLocator.Current.GetInstance<ITaskService>();
            var taskDtos = taskService.GetAllTasks();
            var mapper = ServiceLocator.Current.GetInstance<IObjectMapper>();
            AllTasks = new ObservableCollection<TaskViewModel>(mapper.Map<IEnumerable<TaskViewModel>>(taskDtos));
        }

        public ObservableCollection<TaskViewModel> AllTasks
        {
            get
            {
                return allTasks;
            }
            set
            {
                allTasks = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AllTasks"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private ObservableCollection<TaskViewModel> allTasks;
    }
}
