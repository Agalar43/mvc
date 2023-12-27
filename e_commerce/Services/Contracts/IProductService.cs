using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        void CreateProduct(ProductDtoForInsertion productDto);
        IQueryable<Product> GetShowCaseProducts(bool trackChanges);
        IEnumerable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        void DeleteOneProduct(int id);
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product? GetOneProduct(int id, bool trackChanges);

        Product? RankingUpdate(int id);
        Product? AddCommets(int id);
        
    }
}