using MyShopperStock.Core;
using MyShopperStock.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShopperStock.WebUI.Controllers
{
  //  [Authorize(Roles = "Admin")]
    public class ProductManagerController : Controller
    {
        IRepository<Product> productRepo;

        public ProductManagerController(IRepository<Product> context) {
            this.productRepo = context;
        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> product=productRepo.collection().ToList();
            return View(product);
        }

        public ActionResult Create() {
            return View();
        }




    }
}