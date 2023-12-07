using Entities.Models;
namespace Repositories.Contracts
{
    public interface IProductRepository: IRepositoriesBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);
        Product? GetOneProduct(int id ,bool trackChanges);
    }

    
}