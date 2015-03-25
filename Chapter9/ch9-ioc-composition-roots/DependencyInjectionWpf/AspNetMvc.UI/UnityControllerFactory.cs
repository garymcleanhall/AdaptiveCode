using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AspNetMvc.UI
{
    public class ControllerFactoryUnity : DefaultControllerFactory
    {
        private readonly IUnityContainer container;

        public ControllerFactoryUnity(IUnityContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                var controller = container.Resolve(controllerType) as IController;
                if (controller == null)
                {
                    controller = base.GetControllerInstance(requestContext, controllerType);
                }
                if (controller != null)
                    return controller;
            }
            requestContext.HttpContext.Response.StatusCode = 404;
            return container.Resolve<IController>("Error");
        }
    }
}