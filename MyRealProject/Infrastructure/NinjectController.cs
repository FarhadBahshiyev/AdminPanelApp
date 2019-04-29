using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MyRealProject.Realization;
using MyRealProject.Repository;
using Ninject;

namespace MyRealProject.Infrastructure
{
    public class NinjectController : DefaultControllerFactory
    {
        private IKernel kernel;

        public NinjectController()
        {
            kernel = new StandardKernel();
            MainBindings();

        }
        
        private void MainBindings()
        {
            kernel.Bind<INewsRepository>().To<NewsRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IPictureRepository>().To<PictureRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }
    }
}