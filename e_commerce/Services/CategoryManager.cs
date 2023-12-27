using Entities.Models;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Category> GetAllCategory(bool trackChanges)
        {
            return _manager.Category.FindAll(trackChanges);
        }

        public Category GetCategoryProduct(int id)
        {
            return _manager.Category.FindProduct(id);
        }
    }
}