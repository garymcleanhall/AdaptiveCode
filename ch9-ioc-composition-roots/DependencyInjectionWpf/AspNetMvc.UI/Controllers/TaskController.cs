using ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace AspNetMvc.UI.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;
        private readonly IObjectMapper mapper;

        public TaskController(ITaskService taskService, IObjectMapper mapper)
        {
            this.taskService = taskService;
            this.mapper = mapper;
        }

        public ActionResult List()
        {
            var taskDtos = taskService.GetAllTasks();
            var taskViewModels = mapper.Map<IEnumerable<TaskViewModel>>(taskDtos);
            return View(taskViewModels);
        }
    }
}