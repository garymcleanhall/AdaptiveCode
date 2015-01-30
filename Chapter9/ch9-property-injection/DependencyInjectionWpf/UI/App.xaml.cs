using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

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

            var settings = new ApplicationSettings();
            var taskService = new TaskServiceAdo();
            var objectMapper = new MapperAutoMapper();
            controller = new TaskListController(taskService, objectMapper, settings);
            MainWindow = new TaskListView(controller);
            MainWindow.Show();

            controller.OnLoad();
        }

        private void CreateMappings()
        {
            AutoMapper.Mapper.CreateMap<TaskDto, TaskViewModel>();
        }

        private TaskListController controller;
    }
}
