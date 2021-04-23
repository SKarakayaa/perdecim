using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTO.Address;

namespace Business.Abstract
{
    public interface IUserAddressService
    {
        Task<List<AddressViewDTO>> GetListAsync(int userId);
        Task<List<City>> GetCityList();
        Task<List<District>> GetDistrictListByCityIdAsync(int cityId);
        Task<List<Neighborhood>> GetNeighborhoodListByDistrictIdAsync(int districtId);
    }
}