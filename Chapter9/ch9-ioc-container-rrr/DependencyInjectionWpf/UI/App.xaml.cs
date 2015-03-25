using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

using ServiceInterfaces;
using ViewModels;
using Controllers;

namespace UI
{
    public partial class App : Application
    {
        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            CreateMappings();

            ioc = new IocConfiguration();
            ioc.Register();

            MainWindow = ioc.Resolve();
            MainWindow.Show();

            ((TaskListController)MainWindow.DataContext).OnLoad();
        }

        private void OnApplicationExit(object sender, ExitEventArgs e)
        {
            ioc.Release();
        }

        private void CreateMappings()
        {
            AutoMapper.Mapper.CreateMap<TaskDto, TaskViewModel>();
        }

        private IocConfiguration ioc;
    }
}
