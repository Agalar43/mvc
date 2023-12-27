using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IAuthService _authService;
        private readonly IAddressService _addressService;
        private readonly ICommentService _commentService;
        public ServiceManager(ICategoryService categoryService, IProductService productService, IOrderService orderService, IAuthService authService, IAddressService addressService, ICommentService commentService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _authService = authService;
            _addressService = addressService;
            _commentService = commentService;
        }

        public IProductService ProductService => _productService;

        public ICategoryService CategoryService => _categoryService;

        public IOrderService OrderService => _orderService;

        public IAuthService AuthService => _authService;

        public IAddressService AddressService => _addressService;

        public ICommentService CommentService => _commentService;
    }
}