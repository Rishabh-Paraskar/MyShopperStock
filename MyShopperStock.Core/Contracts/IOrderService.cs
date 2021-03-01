using MyShopperStock.Core.Models;
using MyShopperStock.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopperStock.Core.Contracts
{
    public interface IOrderService
    {
        void CreateOrder( Order BaseOrder, List<BasketItemViewModel> BasketItems);
        List<Order> GetOrderList();
        Order GetOrder(string Id);
        void UpdateOrder(Order UpdateOrder);
    }
}
