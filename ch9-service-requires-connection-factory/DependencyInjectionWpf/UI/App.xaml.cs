using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Data.SqlClient;

using Microsoft.Practices.Unity;

using ServiceImplementations;
using Controllers;
using ServiceInterfaces;
using ViewModels;

namespace UI
{
    public partial class App : Application
    {
        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            CreateMappings();

            container = new UnityContainer();
            container.RegisterType<ISettings, ApplicationSettings>();
            container.RegisterType<IConnectionFactory, ConnectionFactorySql>();
            container.RegisterType<IObjectMapper, MapperAutoMapper>();
            container.RegisterType<ITaskService, TaskServiceAdo>();
            container.RegisterType<TaskListController>();
            container.RegisterType<TaskListView>();

            MainWindow = container.Resolve<TaskListView>();
            MainWindow.Show();

            ((TaskListController)MainWindow.DataContext).OnLoad();
        }

        private void OnApplicationExit(object sender, ExitEventArgs e)
        {
            container.Dispose();
        }

        private void CreateMappings()
        {
            AutoMapper.Mapper.CreateMap<TaskDto, TaskViewModel>();
        }

        private IUnityContainer container;
    }
}
