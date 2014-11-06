using Microsoft.Practices.Unity;
using Sermo.UI.App_Start;
using Sermo.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sermo.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new UnityContainer();
            var controllerFactory = new UnityControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            IocConfig.RegisterDependencies(container);
        }
    }
}
