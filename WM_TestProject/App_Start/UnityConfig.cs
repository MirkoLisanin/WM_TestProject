using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WM_TestProject.Models;
using WM_TestProject.Repository;

namespace WM_TestProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IProductContext, ProductContext>();
            container.RegisterType<IProduct, Product>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}