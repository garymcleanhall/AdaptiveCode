using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Practices.Unity;

using ServiceImplementations;
using ServiceInterfaces;
using Controllers;

namespace UI
{
    public class IocConfiguration
    {
        public IocConfiguration()
        {
            container = new UnityContainer();
        }

        public void Register()
        {
            container.RegisterType<ISettings, ApplicationSettings>();
            container.RegisterType<IObjectMapper, MapperAutoMapper>();
            container.RegisterType<ITaskService, TaskServiceAdo>();
            container.RegisterType<TaskListController>();
            container.RegisterType<TaskListView>();
        }

        public Window Resolve()
        {
            return container.Resolve<TaskListView>();
        }

        public void Release()
        {
            container.Dispose();
        }

        private readonly IUnityContainer container;
    }
}
