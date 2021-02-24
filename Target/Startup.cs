// <copyright file="Startup.cs" company="Mobilize.Net">
//        Copyright (C) Mobilize.Net info@mobilize.net - All Rights Reserved
//
//        This file is part of the Mobilize Frameworks, which is
//        proprietary and confidential.
//
//        NOTICE:  All information contained herein is, and remains
//        the property of Mobilize.Net Corporation.
//        The intellectual and technical concepts contained herein are
//        proprietary to Mobilize.Net Corporation and may be covered
//        by U.S. Patents, and are protected by trade secret or copyright law.
//        Dissemination of this information or reproduction of this material
//        is strictly forbidden unless prior written permission is obtained
//        from Mobilize.Net Corporation.
// </copyright>

namespace WebSite
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Server.Kestrel.Core;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Mobilize.Web;
    using Mobilize.WebMap.Common.Core;
    using Mobilize.WebMap.Common.DCP;
    using Mobilize.WebMap.Host;
    using Mobilize.WebMap.Server;
    using Mobilize.WebMap.Server.ObservableBinder;
    using Newtonsoft.Json.Serialization;
    using HiringTrackingSite;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Mobilize.WebMap.Common.Server;

    /// <summary>
    /// Startup
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services">the collection of services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddWebMap();
            services.RegisterModelMappers();
            services.RegisterWrappers();
            AddDesktopCompatibilityPlatform(services, Startup.Start);
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddAntiforgery(options => options.HeaderName = WebMapHeaders.AntiforgeryToken);
            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new ObservableModelBinderProvider());
                options.ModelMetadataDetailsProviders.Insert(0, new SuppressChildValidationMetadataProvider(typeof(IObservable)));
            }).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddHealthChecks();
            services.AddSignalR();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        /// </summary>
        /// <param name="app">the application builder</param>
        /// <param name="env">the hosting environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Setting Data Dir
            string baseDir = env.ContentRootPath;
            System.AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(baseDir, "App_Data"));

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.HasValue && context.Request.Path.Value.Contains(".aspx"))
                {
                    context.Request.Headers.Add("WM-API", "true");
                }
                // Call the next delegate/middleware in the pipeline
                await next();
            });
            app.UseSession();
            // app.UseAntiforgeryToken();
            app.UseWebMap();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("DefaultApi", "api/{controller}/{id}");
                endpoints.MapHealthChecks("/health");
                endpoints.MapHub<SignalHub>("/bgw");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }

        private static void AddDesktopCompatibilityPlatform(IServiceCollection services, EntryPoint entryPoint)
        {

            services.AddScoped<ICommandFactory>((serviceProvider) =>
            {
                var refTransversal = serviceProvider.GetService<IReferenceTraversalService>();
                var cmdFactory = new CommandFactory(refTransversal);
                cmdFactory.RegisterCommand("AppRefresh", (receiver, args) =>
                {
                    return new Mobilize.Web.UI.Commands.ApplicationRefreshCommand(refTransversal) { Receiver = receiver, Name = CommandNames.ApplicationRefresh, Arguments = args };
                });
                return cmdFactory;
            });
            services.AddScoped<IApplication>((provider) =>
            {

                var app = new ExtApplication(provider) { EntryPoint = entryPoint };
                return app;
            });
            services.AddTransient<IBackgroundWorkerManager, BackgroundWorkerManager>();
        }
    }
}

