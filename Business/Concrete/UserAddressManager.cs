using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helpers;
using Business.UnitOfWork;
using Entities.Concrete;
using Entities.DTO.Address;

namespace Business.Concrete
{
    public class UserAddressManager : IUserAddressService
    {
        private readonly IUnitOfWork _uow;
        public UserAddressManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<List<AddressViewDTO>> GetListAsync(int userId)
        {
            List<UserAddress> userAddresses = await _uow.UserAddressDAL.GetListAsync(x => x.UserId == userId, new string[] { "City", "District", "Neighborhood" });
            if (userAddresses.Count == 0)
                return new List<AddressViewDTO>();

            List<AddressViewDTO> addressViewDTOs = userAddresses.Select(x => new AddressViewDTO
            {
                AddressType = UserAddressHelpers.GetAddressType(x.AddressType),
                FullAddress = $"{x.Neighborhood.Name} {x.OpenAddress} {x.District.Name}/{x.City.Name.ToUpper()}"
            }).ToList();

            return addressViewDTOs;
        }

        public async Task<List<City>> GetCityList()
        {
            return await _uow.CityDAL.GetListAsync();
        }
        public async Task<List<District>> GetDistrictListByCityIdAsync(int cityId)
        {
            return await _uow.DistrictDAL.GetListAsync(x => x.CityId == cityId);
        }
        public async Task<List<Neighborhood>> GetNeighborhoodListByDistrictIdAsync(int districtId)
        {
            return await _uow.NeighborhoodsDAL.GetListAsync(x => x.DistrictId == districtId);
        }
    }
}