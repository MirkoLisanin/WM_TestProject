using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        // GET: Product
        public ActionResult Index()
        {
            return View(_repository.GetAllProducts());
        }
    }
}