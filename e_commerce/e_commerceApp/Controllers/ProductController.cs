using Entities.Models;
using Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;

namespace e_commerceApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly RepositoryContext _context;
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager, RepositoryContext context)
        {
            _manager = manager;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }

        public IActionResult Get([FromRoute(Name ="id")]int id)
        {
            var product = _manager.ProductService.GetOneProduct(id,false);
            return View(product);
        }

        public IActionResult categories(int id)
        {
            var category = _context.Categories.Include(c => c.products).FirstOrDefault(c => c.CategoryID == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category.products);

        }
        
    }
}