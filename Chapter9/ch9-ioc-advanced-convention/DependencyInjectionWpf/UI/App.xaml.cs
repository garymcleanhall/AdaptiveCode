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

namespace UI
{
    public partial class App : Application
    {
        private void OnApplicationStartup(object sender, StartupEventArgs e)
        {
            CreateMappings();

            container = new UnityContainer();
            container.RegisterTypes(
                AllClasses.FromAssembliesInBasePath().Where(type => type.Assembly.FullName.StartsWith(MatchingAssemblyPrefix)),
                UserDefinedInterfaces, 
                WithName.Default
            );

            MainWindow = container.Resolve<TaskListView>();
            MainWindow.Show();

            ((TaskListController)MainWindow.DataContext).OnLoad();
        }

        private IEnumerable<Type> UserDefinedInterfaces(Type implementingType)
        {
            return WithMappings.FromAllInterfaces(implementingType)
                .Where(iface => iface.Assembly.FullName.StartsWith(MatchingAssemblyPrefix));
        }

        private void CreateMappings()
        {
            AutoMapper.Mapper.CreateMap<TaskDto, TaskViewModel>();
        }

        private IUnityContainer container;

        private const string MatchingAssemblyPrefix = "AdaptiveCode";
    }
}
