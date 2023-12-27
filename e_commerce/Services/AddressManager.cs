using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class AddressManager : IAddressService
    {

        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public AddressManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }


        public void CreateAddress(AddressDtoForInsertion addressDto)
        {
            Address address = _mapper.Map<Address>(addressDto);
            _manager.Address.Create(address);
            _manager.Save();
        }

        public void DeleteAllAddress(string id)
        {
            // Profil silinince Adresleri sil
        }

        public void DeleteOneAddress(int id)
        {
            Address address = GetOneAddress(id, false) ?? new Address();
            _manager.Address.DeletenOneAddress(address);
            _manager.Save();
        }

        public IEnumerable<Address> GetAllAddress(string? id)
        {
            return _manager.Address.GetAllAddress(id);
        }

        public Address? GetOneAddress(int id, bool trackChanges)
        {
            var address = _manager.Address.GetOneAddress(id, trackChanges);
            if (address is null)
                throw new Exception(" Product Not Found");
            return address;
        }
    
    
    
    }
}