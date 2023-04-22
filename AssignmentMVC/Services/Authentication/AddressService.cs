using AssignmentMVC.Models.Entities;
using AssignmentMVC.Models.Identity;
using AssignmentMVC.Repositories;

namespace AssignmentMVC.Services.Authentication
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepo;
        private readonly UserAddressRepository _userAddressRepo;

        public AddressService(AddressRepository addressRepo, UserAddressRepository userAddressRepo)
        {
            _addressRepo = addressRepo;
            _userAddressRepo = userAddressRepo;
        }

        public async Task<AdressEntity> GetOrCreateAsync(AdressEntity addressEntity)
        {
            var entity = await _addressRepo.GetAsync(x =>
            x.StreetName == addressEntity.StreetName &&
            x.PostalCode == addressEntity.PostalCode &&
            x.City == addressEntity.City
         
            );

            entity ??= await _addressRepo.AddAsync(addressEntity);
            return entity!;
        }

        public async Task AddAdressAsync(AppUser user, AdressEntity addressEntity)
        {
            await _userAddressRepo.AddAsync(new UserAdressEntity
            {
                UserId = user.Id,
                Adressid = addressEntity.Id

            });
        }
    }
}
