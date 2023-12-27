using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace e_commerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(true);
            return View(model);
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategory(false), "CategoryID", "CategoryName", "1");
        }

        public IActionResult Create()
        {
            ViewBag.Categories = GetCategoriesSelectList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([FromForm] ProductDtoForInsertion productDto, IFormFile file,IFormFile file1
        ,IFormFile file2,IFormFile file3,IFormFile file4,IFormFile file5,IFormFile file6
        )
        {
            if (ModelState.IsValid)
            {
                List<string> images = new List<string>();
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl = String.Concat("/images/", file.FileName);
                productDto.ImageUrl1 = String.Concat("/images/", file1.FileName);
                productDto.ImageUrl2 = String.Concat("/images/", file2.FileName);
                productDto.ImageUrl3 = String.Concat("/images/", file3.FileName);
                productDto.ImageUrl4 = String.Concat("/images/", file4.FileName);
                productDto.ImageUrl5 = String.Concat("/images/", file5.FileName);
                productDto.ImageUrl6 = String.Concat("/images/", file6.FileName);
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);

            return RedirectToAction("Index");
        }
    }
}