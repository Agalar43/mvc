using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Services.Contracts;

namespace e_commerceApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ProfileController(UserManager<IdentityUser> userManager, IServiceManager manager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _manager = manager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {

            var user = await _userManager.GetUserAsync(User);
            return View(user);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] userDtoForUpdate userDto)
        {
            var user = await _userManager.GetUserAsync(User);
            await _manager.AuthService.Update(userDto, user.Id);
            return View(user);
        }

        public async Task<IActionResult> AddressInformation()
        {
            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;
            var model = _manager.AddressService.GetAllAddress(id);
            return View(model);
        }

        public IActionResult AddressCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddressCreate([FromForm] AddressDtoForInsertion address)
        {
            var user = await _userManager.GetUserAsync(User);
            address.userId = user?.Id;

            if (ModelState.IsValid)
            {
                _manager.AddressService.CreateAddress(address);
                return RedirectToAction("AddressInformation");
            }
            return View();
        }

        public async Task<IActionResult> MyOrders()
        {
            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;
            var model = _manager.OrderService.GetUserOrder(id);
            return View(model);
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword([FromForm] ResetPasswordDto passwordDto)
        {
            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;
            var result = await _manager.AuthService.ResetPassword(passwordDto, id);
            return result.Succeeded
             ? RedirectToAction("Index")
             : View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.AddressService.DeleteOneAddress(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteProfil([FromForm] UserDto userDto)
        {
            var user = await _userManager.GetUserAsync(User);
            var id = user?.Id;
            _manager.AuthService.DeleteUser(id);
            await _signInManager.SignOutAsync();
            return RedirectToAction("Register", "Account");


        }

    }
}