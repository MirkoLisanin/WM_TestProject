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
                        
            container.RegisterType<IProductContext, ProductContext>();

            //change the RegisterType to JSONProductRepository or
            //container.RegisterType<IProductRepository, ProductRepository>();

            //uncomment the following line to use JSONProductRepository and comment above line
            container.RegisterType<IProductRepository, JSONProductRepository>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}