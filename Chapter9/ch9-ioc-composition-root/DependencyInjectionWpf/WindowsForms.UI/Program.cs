using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Practices.Unity;

using ServiceInterfaces;
using ServiceImplementations;
using ServiceImplementations.AutoMapper;
using ServiceImplementations.Generic;
using Controllers;
using ViewModels;

namespace WindowsForms.UI
{
    static class Program
    {
        public static UnityContainer Container;

        [STAThread]
        static void Main()
        {
            AutoMapper.Mapper.CreateMap<TaskDto, TaskViewModel>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Container = new UnityContainer();
            Container.RegisterType<ISettings, ApplicationSettings>();
            Container.RegisterType<IObjectMapper, MapperAutoMapper>();
            Container.RegisterType<ITaskService, TaskServiceAdo>();
            Container.RegisterType<TaskListController>();
            Container.RegisterType<TaskListView>();

            var mainForm = Container.Resolve<TaskListView>();
            Application.Run(mainForm);
        }
    }
}
