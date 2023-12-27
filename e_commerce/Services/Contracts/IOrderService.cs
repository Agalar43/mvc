using Entities;
using Entities.Models;

namespace Services.Contracts
{
    public interface IOrderService
    {
        IQueryable<Order> Orders { get; }
        Order? GetOneOrder(string id);
        void Complete(int id);

        void SaveOrder(Order order);
        IEnumerable<Order> GetUserOrder(string? id);

        int NumberOfInProcess { get; }
    }
}