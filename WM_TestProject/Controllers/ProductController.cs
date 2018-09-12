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
    }
}