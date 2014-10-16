using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

using ServiceInterfaces;
using ViewModels;

namespace Controllers
{
    public class TaskListController : INotifyPropertyChanged
    {
        public TaskListController(ITaskService taskService, IObjectMapper mapper, ISettings settings)
        {
            this.taskService = taskService;
            this.mapper = mapper;
            this.settings = settings;
        }

        public void OnLoad()
        {
            taskService.Settings = settings;
            var taskDtos = taskService.GetAllTasks();
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

        private readonly ITaskService taskService;
        private readonly IObjectMapper mapper;
        private readonly ISettings settings;
        private ObservableCollection<TaskViewModel> allTasks;
    }
}
