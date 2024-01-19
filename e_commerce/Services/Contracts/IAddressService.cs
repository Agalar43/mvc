using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface IAddressService
    {
        void CreateAddress(AddressDtoForInsertion address);
        void DeleteOneAddress(int id);

        Address? GetOneAddress(int id, bool trackChanges);
        IEnumerable<Address> GetAllAddress(string? id);

        void DeleteAllAddress(string id);
        Address? GetOrderAddress(int addressId);
    }
}