using Entities.Dtos;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateAddress(Address address) => Create(address);

        public void DeletenOneAddress(Address address) => Remove(address);


        public IQueryable<Address> GetAllAddress(string? id)
        {
            return _context.Address.Where(c => c.userId == id);
        }

        public Address? GetOneAddress(int id, bool trackChanges)
        {
            return FindByCondition(p => p.AddressID.Equals(id), trackChanges);
        }
    }
}