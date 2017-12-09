[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TS.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TS.App_Start.NinjectWebCommon), "Stop")]

namespace TS.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Configuration;
    using Ninject.Web.Common.WebHost;
    using KR.Business.Entities;
    using KR.DbEF.Repositories;
    using KR.Business.Repositories;
    using KR.DbEF;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICustomer<Customer>>().To<CustomerRepositories>();
            kernel.Bind<ILand<Land>>().To<LandRepositories>();
            kernel.Bind<IDesigner<Designer>>().To<DesignerRepositories>();
            kernel.Bind<IZakaz<Zakaz>>().To<ZakazRepositories>();
            kernel.Bind<IWork<Work>>().To<WorkRepositories>();
            kernel.Bind<IZakazInfo<ZakazInfo, zakaz>>().To<ZakazInfoRepositories>();
            kernel.Bind<ISingleOrder<SingleOrder>>().To<SingleOrderRepositories>();
            kernel.Bind<IDifficulties<Difficulties>>().To<DifficultsRepositories>();


        }
    }
}
