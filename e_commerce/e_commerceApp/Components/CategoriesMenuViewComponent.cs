using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;
namespace e_commerceApp.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly RepositoryContext _context;

        public CategoriesMenuViewComponent(RepositoryContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var categroies =_context.Categories.ToList();
            return View(categroies);
        }
    }
}