using Microsoft.AspNetCore.Mvc;

namespace e_commerceApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}