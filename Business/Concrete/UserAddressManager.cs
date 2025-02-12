using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helpers;
using Business.UnitOfWork;
using Core.Utilities.Results;
using Data.Abstract;
using Entities.Concrete;
using Entities.DTO.Address;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class UserAddressManager : IUserAddressService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserAddressDAL _userAddressDAL;
        private readonly ICityDAL _cityDAL;
        private readonly IDistrictDAL _districtDAL;
        private readonly INeighborhoodsDAL _neighborhoodsDAL;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAddressManager(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor, ICityDAL cityDAL, IDistrictDAL districtDAL, INeighborhoodsDAL neighborhoodsDAL, IUserAddressDAL userAddressDAL)
        {
            _uow = uow;
            _cityDAL = cityDAL;
            _districtDAL = districtDAL;
            _neighborhoodsDAL = neighborhoodsDAL;
            _userAddressDAL = userAddressDAL;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<AddressViewDTO>> GetListAsync(int userId)
        {
            List<UserAddress> userAddresses = await _userAddressDAL.GetListAsync(x => x.UserId == userId, x => x.City, x => x.District, x => x.Neighborhood);
            if (userAddresses.Count == 0)
                return new List<AddressViewDTO>();

            List<AddressViewDTO> addressViewDTOs = userAddresses.Select(x => new AddressViewDTO
            {
                AddressId = x.Id,
                AddressType = UserAddressHelpers.GetAddressType(x.AddressType),
                FullAddress = $"{x.Neighborhood.Name} {x.OpenAddress} {x.District.Name}/{x.City.Name.ToUpper()}"
            }).ToList();

            return addressViewDTOs;
        }

        public async Task<UserAddressCreateUpdateDTO> GetUserAddressCreateUpdateDtoModel(int addressId)
        {
            UserAddress userAddress = await _userAddressDAL.GetAsync(x => x.Id == addressId);
            UserAddressCreateUpdateDTO createUpdateDTO = new UserAddressCreateUpdateDTO
            {
                Id = userAddress.Id,
                AddressType = userAddress.AddressType,
                CityId = userAddress.CityId,
                DistrictId = userAddress.DistrictId,
                NeighborhoodId = userAddress.NeighborhoodId,
                OpenAddress = userAddress.OpenAddress
            };
            return createUpdateDTO;
        }

        public async Task<IResult> CreateOrUpdateAsync(UserAddressCreateUpdateDTO createUpdateDTO)
        {
            UserAddress userAddress;
            if (createUpdateDTO.Id != 0)
            {
                userAddress = await _userAddressDAL.GetAsync(x => x.Id == createUpdateDTO.Id);
                userAddress.AddressType = createUpdateDTO.AddressType;
                userAddress.CityId = createUpdateDTO.CityId;
                userAddress.DistrictId = createUpdateDTO.DistrictId;
                userAddress.NeighborhoodId = createUpdateDTO.NeighborhoodId;
                userAddress.OpenAddress = createUpdateDTO.OpenAddress;
                _userAddressDAL.Update(userAddress);
            }
            else
            {
                userAddress = new UserAddress
                {
                    AddressType = createUpdateDTO.AddressType,
                    CityId = createUpdateDTO.CityId,
                    DistrictId = createUpdateDTO.DistrictId,
                    NeighborhoodId = createUpdateDTO.NeighborhoodId,
                    OpenAddress = createUpdateDTO.OpenAddress,
                    UserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst("UserId").Value)
                };
                _userAddressDAL.Add(userAddress);
            }
            int result = await _uow.Complete();
            return ResultHelper<int>.ResultReturn(result);
        }

        public async Task<IResult> DeleteAsync(int addressId)
        {
            UserAddress userAddress = await _userAddressDAL.GetAsync(x => x.Id == addressId);
            _userAddressDAL.Remove(userAddress);
            int result = await _uow.Complete();
            return ResultHelper<int>.ResultReturn(result);
        }

        public async Task<List<City>> GetCityList() => await _cityDAL.GetListAsync();
        public async Task<List<District>> GetDistrictListByCityIdAsync(int cityId) => await _districtDAL.GetListAsync(x => x.CityId == cityId);
        public async Task<List<Neighborhood>> GetNeighborhoodListByDistrictIdAsync(int districtId) => await _neighborhoodsDAL.GetListAsync(x => x.DistrictId == districtId);
    }
}