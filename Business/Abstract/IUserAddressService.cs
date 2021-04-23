using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO.Address;

namespace Business.Abstract
{
    public interface IUserAddressService
    {
        Task<List<AddressViewDTO>> GetListAsync(int userId);
        Task<List<City>> GetCityList();
        Task<IResult> CreateOrUpdateAsync(UserAddressCreateUpdateDTO createUpdateDTO);
        Task<IResult> DeleteAsync(int addressId);
        Task<UserAddressCreateUpdateDTO> GetUserAddressCreateUpdateDtoModel(int addressId);
        Task<List<District>> GetDistrictListByCityIdAsync(int cityId);
        Task<List<Neighborhood>> GetNeighborhoodListByDistrictIdAsync(int districtId);
    }
}