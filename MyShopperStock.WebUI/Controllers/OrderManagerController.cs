using MyShopperStock.Core.Contracts;
using MyShopperStock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShopperStock.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderManagerController : Controller
    {
        IOrderService OrderService;

        public OrderManagerController(IOrderService orderservice)
        {
            this.OrderService = orderservice;
        }

        // GET: OrderManager
        public ActionResult Index()
        {
            List<Order> orders = OrderService.GetOrderList();
            return View(orders);
        }

        public ActionResult updateOrder(string id)
        {
            ViewBag.statusList = new List<string>()
            {
                "Order Created",
                "Payment Processed",
                "Order Shipped",
                "Order Completed"
            };
            Order order = OrderService.GetOrder(id);
            return View(order);
        }

        [HttpPost]
        public ActionResult updateOrder(Order updatedOrder, string id)
        {
            Order order = OrderService.GetOrder(id);

            order.OrderStatus = updatedOrder.OrderStatus;
            OrderService.UpdateOrder(order);
            return RedirectToAction("Index");
        }
    }
}