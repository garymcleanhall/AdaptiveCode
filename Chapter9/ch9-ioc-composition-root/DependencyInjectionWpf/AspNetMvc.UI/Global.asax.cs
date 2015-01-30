using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using AspNetMvc.UI.Controllers;
using Microsoft.Practices.Unity;
using ServiceImplementations;
using ServiceImplementations.AutoMapper;
using ServiceImplementations.Generic;
using ServiceInterfaces;
using ViewModels;

namespace AspNetMvc.UI
{
    public class MvcApplication : HttpApplication
    {
        public static UnityContainer Container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapper.Mapper.CreateMap<TaskDto, TaskViewModel>();

            Container = new UnityContainer();
            Container.RegisterType<ISettings, ApplicationSettings>();
            Container.RegisterType<IObjectMapper, MapperAutoMapper>();
            Container.RegisterType<ITaskService, TaskServiceAdo>();
            Container.RegisterType<TaskViewModel>();
            Container.RegisterType<TaskController>();

            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory(Container));
        }
    }
}
