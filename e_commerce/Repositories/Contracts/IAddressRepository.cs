using Entities.Dtos;
using Entities.Models;

namespace Repositories.Contracts
{
    public interface IAddressRepository:IRepositoriesBase<Address>
    {
        void CreateAddress(Address address);
        void DeletenOneAddress(Address address);
        IQueryable<Address> GetAllAddress(string? id);
        Address? GetOneAddress(int id, bool trackChanges);
        Address? GetOrderAddress(int addressId);
    }
}