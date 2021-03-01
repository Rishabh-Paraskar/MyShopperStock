using MyShopperStock.Core;
using MyShopperStock.Core.Contracts;
using MyShopperStock.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShopperStock.WebUI.Controllers
{  // this class is using to handle all the product related work homepage, addproduct, edit, delete, list of product
  //  [Authorize(Roles = "Admin")]
    public class ProductManagerController : Controller
    {
        IRepository<Product> ProductContext;
        IRepository<ProductCategory> ProductCategoryContext;
        public ProductManagerController(IRepository<Product> productcontext, IRepository<ProductCategory> productcategorycontext) {
            this.ProductContext = productcontext;
            this.ProductCategoryContext = productcategorycontext;
        }

        // GET: ProductManager
        // this method returns the list of products
        public ActionResult Index()
        {
            List<Product> product= ProductContext.collection().ToList();
            return View(product);
        }

        // this method retuns creates new product page
        public ActionResult Create() {
            ProductManagerViewModel ProductManagerViewModel = new ProductManagerViewModel();
            ProductManagerViewModel.Product = new Product();
            ProductManagerViewModel.ProductCategory = ProductCategoryContext.collection();
            return View(ProductManagerViewModel);
        }
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {

                if (file != null)
                {
                    product.Image = product.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);
                }
                ProductContext.insert(product);
                ProductContext.commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Product product = ProductContext.find(Id);
            if (product == null)
            {
                return HttpNotFound();

            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.Product = product;
                viewModel.ProductCategory = ProductCategoryContext.collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string Id, HttpPostedFileBase file)
        {
            Product productTOEdit = ProductContext.find(Id);
            if (productTOEdit == null)
            {
                return HttpNotFound();

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                else
                {
                    if (file != null)
                    {
                        productTOEdit.Image = product.Id + Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath("//Content//ProductImages//") + productTOEdit.Image);

                    }
                    productTOEdit.Category = product.Category;
                    productTOEdit.Description = product.Description;
                    productTOEdit.Name = product.Name;
                    productTOEdit.Price = product.Price;


                    ProductContext.commit();
                    return RedirectToAction("Index");
                }
            }

        }

        public ActionResult Delete(string Id)
        {
            Product productToDelete = ProductContext.find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                return View(productToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = ProductContext.find(Id);
            if (productToDelete == null)
            {
                return HttpNotFound();

            }
            else
            {
                ProductContext.delete(Id);
                ProductContext.commit();
                return RedirectToAction("index");
            }
        }

    }
}