﻿using System;
using Alienlab.Framework.Design;
using Alienlab.Practices.Utilities;
using FileInfoMagic.Infrastructure.Factories;
using FileInfoMagic.Services.Interfaces;
using Unity;
using Unity.Lifetime;

namespace FileInfoMagic.Infrastructure
{
    public static class UnityConfig
    {
        #region Unity Container

        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;

        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from app.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // Register your type's mappings here.
            container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());
            container.RegisterType<IServiceFactory<IDialogService>, DialogServiceFactory>();
            container.RegisterType<IServiceFactory<IEditorService>, EditorServiceFactory>();
        }
    }
}
