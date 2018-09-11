using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WM_TestProject.Models;

namespace WM_TestProject.Repository
{
    public class ProductRepository : IProductRepository
    {
        ProductContext db = new ProductContext();
        public IList<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void EditProduct(Product p)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product p)
        {
            throw new NotImplementedException();
        }


    }
}