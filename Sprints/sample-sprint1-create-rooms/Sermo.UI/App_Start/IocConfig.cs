using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sermo.Contracts;
using Sermo.AdoNet;

using Microsoft.Practices.Unity;
using System.Data.Common;

namespace Sermo.UI.App_Start
{
    public static class IocConfig
   { 
        public static void RegisterDependencies(IUnityContainer container)
        {
            IocConfig.container = container;
            
            container.RegisterType<IApplicationSettings, ConfigAppSettings>();
            container.RegisterType<IRoomRepository, AdoNetRoomRepository>();

            container.RegisterType<DbProviderFactory>(new InjectionFactory(c => 
                DbProviderFactories.GetFactory(c.Resolve<IApplicationSettings>().GetValue("DatabaseProviderName"))));
        }

        private static IUnityContainer container;
    }
}