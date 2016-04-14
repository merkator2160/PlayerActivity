using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Contracts.Interfaces;
using FileSystemJsonActivitySaver;
using Microsoft.Practices.Unity;
using System;
using System.Text;

namespace BusinessLogic.Infrastructure
{
    internal static class UnityConfig
    {
        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////
        public static IUnityContainer GetConfiguredContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }
        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IActivityRepository, JsonActivitySaver>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(
                    new InjectionParameter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\playerActivities.json"),
                    new InjectionParameter(Encoding.UTF8))
            );
            container.RegisterInstance(AutoMapperConfig.GetConfiguredMapper());
            container.RegisterType<IActivityService, ActivityService>(new ContainerControlledLifetimeManager(),
                new InjectionConstructor(
                    new InjectionParameter(container.Resolve<IActivityRepository>()),
                    new InjectionParameter(container.Resolve<IMapper>()))
            );
        }
    }
}