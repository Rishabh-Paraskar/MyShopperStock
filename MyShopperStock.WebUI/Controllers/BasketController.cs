using MyShopperStock.Core;
using MyShopperStock.Core.Contracts;
using MyShopperStock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShopperStock.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService BasketService;
        IOrderService OrderService;
        IRepository<Customer> CustomerContext;

        public BasketController(IBasketService basketservice, IOrderService orderservice,IRepository<Customer> context) 
        {
            this.BasketService = basketservice;
            this.OrderService = orderservice;
            this.CustomerContext = context;
        }

        // GET: Basket
        public ActionResult Index()
        {
            var model = BasketService.GetBasketItem(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(String id)
        {
            BasketService.AddToBasket(this.HttpContext, id);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromBasket(String id)
        {
            BasketService.RemoveFromBasket(this.HttpContext, id);
            return RedirectToAction("Index");
        }

        public PartialViewResult BasketsSummary()
        {
            var basketSummary = BasketService.GetBasketSummary(this.HttpContext);
            return PartialView(basketSummary);
        }

        [Authorize]
        public ActionResult CheckOut()
        {
            Customer cus = CustomerContext.collection().FirstOrDefault(c => c.Email == User.Identity.Name);
            if (cus != null)
            {

                Order order = new Order()
                {
                    Email = cus.Email,
                    Address = cus.Address,
                    FirstName = cus.FirstName,
                    SurName = cus.LastName,
                    ZipCode = cus.ZipCode
                };
                return View(order);
            }
            else
            {
                return RedirectToAction("Thankyou");
            }

        }

        [HttpPost]
        [Authorize]
        public ActionResult CheckOut(Order order)
        {

            var basketItems = BasketService.GetBasketItem(this.HttpContext);
            order.OrderStatus = "Order created";
            order.Email = User.Identity.Name;

            order.OrderStatus = "Payment Processed";
            OrderService.CreateOrder(order, basketItems);
            BasketService.ClearBasket(this.HttpContext);

            return RedirectToAction("Thankyou", new { orderId = order.Id });
        }

        public ActionResult Thankyou(string orderId)
        {

            ViewBag.orderId = orderId;
            return View();
        }

    }
}