namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }

        IOrderRepository Order { get; }

        IAddressRepository Address{get;}

        ICommentRepository Comment{get;}
        void Save();
    }
}