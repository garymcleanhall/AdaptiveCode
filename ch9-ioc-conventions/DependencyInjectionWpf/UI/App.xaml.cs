using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

using Microsoft.Practices.Unity;

using ServiceImplementations;
using Controllers;
using ServiceInterfaces;
using ViewModels;
using System.Reflection;

namespace UI
{
    public partial class App : Application
    {
        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            CreateMappings();

            container = new UnityContainer();
            container.RegisterTypes(
                AllClasses.FromAssembliesInBasePath(),
                WithMappings.FromMatchingInterface,
                WithName.Default
            );
            
            MainWindow = container.Resolve<TaskListView>();
            MainWindow.Show();

            ((TaskListController)MainWindow.DataContext).OnLoad();
        }

        private void CreateMappings()
        {
            AutoMapper.Mapper.CreateMap<TaskDto, TaskViewModel>();
        }

        private IUnityContainer container;
    }
}
