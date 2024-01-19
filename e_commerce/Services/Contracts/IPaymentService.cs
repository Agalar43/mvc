using Entities.Models;

namespace Services.Contracts
{
    public interface IPaymentService
    {
        void CreateCustomer(string? userName);
        void CreateOrPaymentIntent();
    }
}