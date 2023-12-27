using e_commerceApp.Models;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace e_commerceApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly Cart _cart;

        private readonly UserManager<IdentityUser> _userManager;
        public OrderController(IServiceManager manager, Cart cart, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _cart = cart;
            _userManager = userManager;
        }
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _manager.AddressService.GetAllAddress(user?.Id);
            ViewBag.Address = AddressSelectList();
            return View(new OrderCompleteViewModel()
            {
                address=model,
                order = new Order()
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout([FromForm] Order order)
        {
            var user = await _userManager.GetUserAsync(User);


            if (_cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry,your cart is empty.");
            }
            if (ModelState.IsValid)
            {
                order.userId = user?.Id;
                order.Lines = _cart.Lines.ToArray();
                _manager.OrderService.SaveOrder(order);
                _cart.Clear();
                return RedirectToPage("/Complete", new { OrderId = order.OrderID });
            }
            else
            {
                return View();
            }
        }

        private async Task<SelectList> AddressSelectList()
        {
            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;
            return new SelectList(_manager.AddressService.GetAllAddress(id), "AddressID", "AddressName", "1");
        }

    }
}