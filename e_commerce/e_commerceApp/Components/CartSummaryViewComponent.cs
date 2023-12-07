using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace e_commerceApp.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly Cart _cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            _cart = cartService;
        }
        public string Invoke()
        {
            return _cart.Lines.Count().ToString();
        }
    }
}