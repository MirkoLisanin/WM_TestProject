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
            return db.Products.Find(id);
        }

        public void EditProduct(Product p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void AddProduct(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
        }


    }
}