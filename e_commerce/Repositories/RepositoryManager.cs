using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        
        private readonly IAddressRepository _addressRepository;
        private readonly ICategoryRepository _categoryRepository;

        private readonly ICommentRepository _commentRepository;
        public RepositoryManager(RepositoryContext context, IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository, IAddressRepository addressRepository, ICommentRepository commentRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _addressRepository = addressRepository;
            _commentRepository = commentRepository;
        }

        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IOrderRepository Order =>_orderRepository;

        public IAddressRepository Address => _addressRepository;

        public ICommentRepository Comment => _commentRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}