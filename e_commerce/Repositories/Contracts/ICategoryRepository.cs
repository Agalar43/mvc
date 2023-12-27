using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICategoryRepository : IRepositoriesBase<Category>
    {
        Category FindProduct(int id);
    }
}