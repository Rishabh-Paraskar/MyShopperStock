using MyShopperStock.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyShopperStock.Core.Contracts
{
    public interface IBasketService
    {
        void AddToBasket(HttpContextBase httpcontext, string produtid);
        void RemoveFromBasket(HttpContextBase httpcontext, string itemid);
        List<BasketItemViewModel> GetBasketItem(HttpContextBase httpcontext);
        BasketSummaryViewModel  GetBasketSummary(HttpContextBase httpcontext);
        void ClearBasket(HttpContextBase httpcontext);
    }
}
