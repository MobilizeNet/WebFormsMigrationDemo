// <copyright file="RegistrationClass.cs" company="Mobilize.Net">
//       Copyright (c) 2018 Mobilize, Inc. All Rights Reserved,
//       All classes are provided for customer use only,
//       all other use is prohibited without prior written consent from Mobilize.Net,
//       no warranty express or implied,
//       use at own risk.
// </copyright>

namespace WebSite
{
    using System.Collections.Generic;
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Mobilize.Web;
    using Mobilize.Web.DataTransferMapper;
    using Mobilize.Web.UI.DataTransfer;
    using Mobilize.WebMap.Common.Core;
    using Mobilize.WebMap.Common.Core.ObservableWrapper;
    using Mobilize.WebMap.Common.Messaging;
    using Mobilize.WebMap.Core.ObservableWrapper;
    using Mobilize.WebMap.Messaging;

    /// <summary>
    /// Registration for Wrappers and Mappers
    /// </summary>
    public static class RegistrationClass
    {
        private static List<Assembly> assembliesForRegistrations = AssemblyRegistration.GetAssembliesForRegistration(Assembly.GetEntryAssembly());

        /// <summary>
        /// Registers the model projectors.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterModelMappers(this IServiceCollection services)
        {
            services.AddSingleton<IMapperCatalog>((provider) =>
            {
                var loggerFactory = provider.GetService<ILoggerFactory>();
                var catalog = new MapperCatalog(loggerFactory);
                var logger = loggerFactory.CreateLogger("Information");
                catalog.AddMapperFactory(new DefaultMapperFactory());

                new Mobilize.Web.UI.BundleBasic.DTO.Registrations().RegisterMappers(catalog, logger);
                catalog.AddMapper(new Mobilize.Web.DataTransfer.ComboBoxItemMapper());

                catalog.AddMapper(new Mobilize.Web.DataTransfer.ComboBoxMapper<Mobilize.Web.ComboBox, Mobilize.Web.DataTransfer.ComboBox>());
                // register mappers from Assemblies for registration (it includes current Assembly)
                // AssemblyRegistration.RegisterMappers(assembliesForRegistrations, logger, catalog);

                return catalog;
            });
        }

        /// <summary>
        /// Registers the wrappers.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void RegisterWrappers(this IServiceCollection services)
        {
            services.AddSingleton<IObservableWrapperCatalog>(
              (provider) =>
              {
                  var catalog = new ObservableWrapperCatalog();

                  // register wrappers from referenced Assemblies
                  AssemblyRegistration.RegisterWrappers(assembliesForRegistrations, catalog);

                  // assembliesForRegistrations is not longer required, so is cleared out.
                  assembliesForRegistrations.Clear();
                  assembliesForRegistrations = null;
                  return catalog;
              });
        }
    }
}

