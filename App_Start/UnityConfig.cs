using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using TechPlacement.Service.Interface;
using TechPlacement.Service.Repository;

namespace TechPlacement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IHomeRepository, HomeRepository>();
            container.RegisterType<IDashBoardRepository, DashBoardRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}