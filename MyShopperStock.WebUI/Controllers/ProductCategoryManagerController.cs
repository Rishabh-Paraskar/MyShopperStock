using MyShopperStock.Core;
using MyShopperStock.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShopperStock.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductCategoryManagerController : Controller
    {
        IRepository<ProductCategory> ProductCategoryContext;

        public ProductCategoryManagerController(IRepository<ProductCategory> productcategorycontext) 
        {
            this.ProductCategoryContext = productcategorycontext;
        }

        // GET: ProductCategoryManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategory = ProductCategoryContext.collection().ToList();
            return View(productCategory);
        }

        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                ProductCategoryContext.insert(productCategory);
                ProductCategoryContext.commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCategory productCategory = ProductCategoryContext.find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(productCategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory productCategoryTOEdit = ProductCategoryContext.find(Id);
            if (productCategoryTOEdit == null)
            {
                return HttpNotFound();

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }
                else
                {
                    productCategoryTOEdit.Category = productCategory.Category;
                    ProductCategoryContext.commit();
                    return RedirectToAction("Index");
                }
            }

        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = ProductCategoryContext.find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(productCategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = ProductCategoryContext.find(Id);
            if (productCategoryToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                ProductCategoryContext.delete(Id);
                ProductCategoryContext.commit();
                return RedirectToAction("index");
            }
        }
    }
}