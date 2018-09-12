using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WM_TestProject.Models;

namespace WM_TestProject.Repository
{
    public class ProductRepository : IProductRepository
    {        
        IProductContext _db;
        public ProductRepository(IProductContext db)
        {
            _db = db;
        }
        public IList<Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _db.Products.Find(id);
        }

        public void EditProduct(Product p)
        {
            _db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void AddProduct(Product p)
        {
            _db.Products.Add(p);
            _db.SaveChanges();
        }

    }
}