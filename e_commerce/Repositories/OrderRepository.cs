using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => _context.Orders
            .Include(o => o.Lines )
            .ThenInclude(cl => cl.Product)
            .Include(o => o.address)
            .OrderBy(o => o.Shipped)
            .ThenByDescending(o => o.OrderID);

        public int NumberOfInProcess => _context.Orders.Count(o => o.Shipped.Equals(false));

        public void Complete(int id)
        {
            var order = FindByCondition(o => o.OrderID.Equals(id), true);
            if (order is null)
            {
                throw new Exception("Order could not found!");
            }
            order.Shipped = true;

        }

        public Order? GetOneOrder(int id)
        {
            return FindByCondition(o => o.OrderID.Equals(id), true);
        }

        public IEnumerable<Order> GetUserOrder(string? id)
        {
            return _context.Orders
            .Include(o => o.Lines)
             .ThenInclude(cl => cl.Product)
            .Include(a=>a.address)
             .OrderBy(o => o.Shipped)
             .Where(o => o.userId == id);
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}