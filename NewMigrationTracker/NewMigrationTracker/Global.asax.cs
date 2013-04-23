using NewMigrationTracker.Entities;
using NewMigrationTracker.Services.DataServices;
using NewMigrationTracker_Services.Interfaces;
using Ninject;
using Ninject.Web.Common;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NewMigrationTracker
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        protected void Application_Start()
        {

            //  RegisterDependencyResolver();
        }

        //private void RegisterDependencyResolver()
        //{
        //    var kernel = new StandardKernel();
        //    kernel.Bind<IService<User>>().To<UserService>();
        //    DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        //}

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }



        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IService<User>>().To<UserService>();
            return kernel;


            //kernel.Bind<IService<User>>().To<UserService>();
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}