﻿using MyShopperStock.Core.Contracts;
using MyShopperStock.Core.Models;
using MyShopperStock.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopperStock.Service
{
    public class OrderService : IOrderService
    {
        IRepository<Order> OrderContext;

        public OrderService(IRepository<Order> ordercontext) {
            this.OrderContext = ordercontext;
        }

        public void CreateOrder(Order BaseOrder, List<BasketItemViewModel> BasketItems)
        {
            foreach (var item in BasketItems)
            {
                BaseOrder.orderItems.Add(new OrderItem()
                {

                    ProductId = item.Id,
                    Image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity

                });
            }
            OrderContext.insert(BaseOrder);
            OrderContext.commit();
        }

        public Order GetOrder(string Id)
        {
            return OrderContext.find(Id);
        }

        public List<Order> GetOrderList()
        {
            return OrderContext.collection().ToList();
        }

        public void UpdateOrder(Order UpdatedOrder)
        {
            OrderContext.update(UpdatedOrder);
            OrderContext.commit();
        }
    }
}
