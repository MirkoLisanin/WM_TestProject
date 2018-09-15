using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WM_TestProject.Models;
using System.Drawing;

namespace WM_TestProject.Repository
{
    public class JSONProductRepository : IProductRepository
    {
        
        //path to JSON file
        static string path = HttpContext.Current.Request.MapPath("~/JSON/Product.json");

        //read all data from file path
        private static string ReturnJsonData()
        {
            //Check if file exists - if no create new empty file
            if (!File.Exists(path))
            {                
                List<Product> lp = new List<Product>();
                string s = JsonConvert.SerializeObject(lp);
                File.WriteAllText(path, s);
            }
            return File.ReadAllText(path);
        }
        

        List<Product> ReturnListOfProducts() {
            //TODO: check if there is an error with deserialise
            return JsonConvert.DeserializeObject<List<Product>>(ReturnJsonData());
        } 

        public void AddProduct(Product p)
        {
            //find last entry by ID and increase by 1
            //to be added to new entry
            p.ProductId = ReturnListOfProducts().Last().ProductId + 1;
            ReturnListOfProducts().Add(p);
            var output = JsonConvert.SerializeObject(ReturnListOfProducts(), Formatting.Indented);
            File.WriteAllText(HttpContext.Current.Server.MapPath(path), output);
        }

        public void EditProduct(Product p)
        {            
            foreach (var p1 in ReturnListOfProducts())
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
            var output = JsonConvert.SerializeObject(ReturnListOfProducts(), Formatting.Indented);
            File.WriteAllText(HttpContext.Current.Server.MapPath(path), output);            
        }

        public IList<Product> GetAllProducts()
        {            
            return ReturnListOfProducts();
        }

        public Product GetProductById(int id)
        {
            var product = JsonConvert.DeserializeObject<List<Product>>(ReturnJsonData()).Find(p=>p.ProductId == id);
            return product;
        }
    }
}