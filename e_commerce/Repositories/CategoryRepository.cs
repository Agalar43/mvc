using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
            
        }

        public Category FindProduct(int id)
        {
           return  _context.Categories.Include(c => c.products).FirstOrDefault(c => c.CategoryID == id);
        }
    }
}