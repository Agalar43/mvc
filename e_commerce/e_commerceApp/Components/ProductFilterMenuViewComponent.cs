using Microsoft.AspNetCore.Mvc;

namespace e_commerceApp.Components
{
    public class ProductFilterMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}