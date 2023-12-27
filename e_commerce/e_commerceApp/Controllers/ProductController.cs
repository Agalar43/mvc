using Entities.Models;
using Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Entities.RequestParameters;
using e_commerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Entities.Dtos;

namespace e_commerceApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly RepositoryContext _context;
        private readonly IServiceManager _manager;
        private readonly UserManager<IdentityUser> _userManager;
        public ProductController(IServiceManager manager, RepositoryContext context, UserManager<IdentityUser> userManager)
        {
            _manager = manager;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(ProductRequestParameters p)
        {
            ViewData["Title"] = "Products";
            var products = _manager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrenPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotelItems = _manager.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination
            });
        }

        public async Task<IActionResult> Get([FromRoute(Name = "id")] int id)
        {
            var product = _manager.ProductService.GetOneProduct(id, false);
            var updatedProduct = _manager.ProductService.RankingUpdate(id);
            ViewBag.UpdatedProduct = updatedProduct;
            var comment = _manager.CommentService.getProductComment(id).ToList();
            var user = await _userManager.GetUserAsync(User);

            return View(new ProductViewModel()
            {
                Product = product,
                Comment = comment,
                UserName = user?.UserName
            });
        }

        public IActionResult AddComment()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment([FromForm] CommentDtoForCreation commentDto, [FromRoute(Name = "id")] int id)
        {
            var user = await _userManager.GetUserAsync(User);
            commentDto.UserId = user?.Id;
            commentDto.productId = id;
            _manager.CommentService.AddComment(commentDto);
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }



    }
}