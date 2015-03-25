using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Microsoft.Practices.Unity;

namespace Sermo.UI.Controllers
{
    public class UnityControllerFactory : DefaultControllerFactory
    {
        public UnityControllerFactory(IUnityContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            IController controller = null;
            if (controllerType != null)
            {
                controller = container.Resolve(controllerType) as IController;
            }
            else
            {
                controller = base.GetControllerInstance(requestContext, controllerType);
            }

            return controller;
        }

        private readonly IUnityContainer container;
    }
}