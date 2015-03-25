using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;

using Sermo.UI.Contracts;
using Sermo.UI.Controllers;
using Sermo.Data.Contracts;
using Sermo.Data.AdoNet;
using Sermo.Infrastructure.Contracts;

using Microsoft.Practices.Unity;

namespace Sermo.UI.App_Start
{
    public static class IocConfig
   { 
        public static void RegisterDependencies(IUnityContainer container)
        {
            IocConfig.container = container;
            
            container.RegisterType<IApplicationSettings, ConfigAppSettings>();
            container.RegisterType<IViewModelMapper, SimpleRoomViewModelMapper>();
            container.RegisterType<IRoomRepository, AdoNetRoomRepository>();
            container.RegisterType<RepositoryRoomViewModelService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRoomViewModelReader, RepositoryRoomViewModelService>();
            container.RegisterType<IRoomViewModelWriter, RepositoryRoomViewModelService>();

            container.RegisterType<DbProviderFactory>(new InjectionFactory(c => 
                DbProviderFactories.GetFactory(c.Resolve<IApplicationSettings>().GetValue("DatabaseProviderName"))));
        }

        private static IUnityContainer container;
    }
}