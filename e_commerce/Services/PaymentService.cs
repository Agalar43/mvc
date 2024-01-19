using Entities.Models;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;
using Stripe;

namespace Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepositoryManager _manager;
        private readonly Cart _cart;
        private readonly IConfiguration _config;
        public PaymentService(IRepositoryManager manager, Cart cartService, IConfiguration config)
        {
            _manager = manager;
            _cart = cartService;
            _config = config;
        }

        public void CreateCustomer(string? userName)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];
            var customerOptions = new CustomerCreateOptions
            {
                Name = userName
                // Diğer müşteri bilgilerini de ekleyebilirsiniz
            };
            var customerService = new CustomerService();
            var customer = customerService.Create(customerOptions);
        }

        public void CreateOrPaymentIntent()
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];
            var totalPrice = (long)_cart.Lines.Sum(cart => cart.Product.unitPrice * cart.Quantity);
            var options = new PaymentIntentCreateOptions
            {
                Amount = totalPrice,
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" }
            };
            var service = new PaymentIntentService();
            var paymentIntent = service.Create(options);
        }

    }
}