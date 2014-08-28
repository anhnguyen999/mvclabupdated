using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using MvcMovie.Core;
using MvcMovie.Infrastructure;
using MvcMovie.Core.Interface;

namespace MvcMovie
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMovieRepository, MovieRepository>();
            container.RegisterType<IBinderRepository, BinderRepository>(); 
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}