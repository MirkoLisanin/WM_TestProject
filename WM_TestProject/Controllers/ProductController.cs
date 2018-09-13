using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WM_TestProject.Models;
using WM_TestProject.Repository;

namespace WM_TestProject.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductRepository _repository;
       
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {            
            return View(_repository.GetAllProducts());
        }
         
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            _repository.AddProduct(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_repository.GetProductById(id));
        }
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            _repository.EditProduct(p);
            return RedirectToAction("Index");
        }

        //json test method
        //just to be sure that i get list of products in JSON format
        public JsonResult Test()
        {            
            IList<Product> listOfProducts = _repository.GetAllProducts();

            string idString = Request.QueryString["id"];
            if (string.IsNullOrWhiteSpace(idString))
            {
                return Json(listOfProducts, JsonRequestBehavior.AllowGet);
            }
            else
            {
                int id = int.Parse(idString);
                Product pr = listOfProducts.FirstOrDefault(p => p.ProductId == id);
                if (pr != null)
                {
                    return Json(pr, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new Product(), JsonRequestBehavior.AllowGet);
                }
            }
            
        }
    }
}