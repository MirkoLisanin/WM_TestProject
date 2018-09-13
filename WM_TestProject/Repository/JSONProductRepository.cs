using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WM_TestProject.Models;

namespace WM_TestProject.Repository
{
    public class JSONProductRepository : IProductRepository
    {
        //path to JSON file
        private static string path = "/JSON/Product.json";
        //read all data from file path
        private static string jsonData = File.ReadAllText(HttpContext.Current.Server.MapPath(path));

        List<Product> listOfProducts = JsonConvert.DeserializeObject<List<Product>>(jsonData);

        public void AddProduct(Product p)
        {
            //find last entry by ID and increase by 1
            //to be added to new entry
            p.ProductId = listOfProducts.Last().ProductId + 1;
            listOfProducts.Add(p);
            var output = JsonConvert.SerializeObject(listOfProducts, Formatting.Indented);
            File.WriteAllText(HttpContext.Current.Server.MapPath(path), output);
        }

        public void EditProduct(Product p)
        {            
            foreach (var p1 in listOfProducts)
            {
                if (p1.ProductId == p.ProductId)
                {
                    p1.ProductId = p.ProductId;
                    p1.ProductName = p.ProductName;
                    p1.ProductDescription = p.ProductDescription;
                    p1.Manufacturer = p.Manufacturer;
                    p1.Category = p.Category;
                    p1.Supplier = p.Supplier;
                    p1.Price = p.Price;
                }
            }
            var output = JsonConvert.SerializeObject(listOfProducts, Formatting.Indented);
            File.WriteAllText(HttpContext.Current.Server.MapPath(path), output);            
        }

        public IList<Product> GetAllProducts()
        {            
            return listOfProducts;
        }

        public Product GetProductById(int id)
        {
            var product = JsonConvert.DeserializeObject<List<Product>>(jsonData).Find(p=>p.ProductId == id);
            return product;
        }
    }
}