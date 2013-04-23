using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NewMigrationTracker
{
    public class NinjectDependencyResolver : IDependencyResolver
    {

        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType, new IParameter[0]);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType, new IParameter[0]);
        }
    }
}