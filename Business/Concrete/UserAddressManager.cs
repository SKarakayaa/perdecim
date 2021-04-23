using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helpers;
using Business.UnitOfWork;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO.Address;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class UserAddressManager : IUserAddressService
    {
        private readonly IUnitOfWork _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAddressManager(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<AddressViewDTO>> GetListAsync(int userId)
        {
            List<UserAddress> userAddresses = await _uow.UserAddressDAL.GetListAsync(x => x.UserId == userId, new string[] { "City", "District", "Neighborhood" });
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
            UserAddress userAddress = await _uow.UserAddressDAL.GetAsync(x => x.Id == addressId);
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
                userAddress = await _uow.UserAddressDAL.GetAsync(x => x.Id == createUpdateDTO.Id);
                userAddress.AddressType = createUpdateDTO.AddressType;
                userAddress.CityId = createUpdateDTO.CityId;
                userAddress.DistrictId = createUpdateDTO.DistrictId;
                userAddress.NeighborhoodId = createUpdateDTO.NeighborhoodId;
                userAddress.OpenAddress = createUpdateDTO.OpenAddress;
                _uow.UserAddressDAL.Update(userAddress);
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
                _uow.UserAddressDAL.Add(userAddress);
            }
            int result = await _uow.Complete();
            return ResultHelper<int>.ResultReturn(result);
        }

        public async Task<IResult> DeleteAsync(int addressId)
        {
            UserAddress userAddress = await _uow.UserAddressDAL.GetAsync(x => x.Id == addressId);
            _uow.UserAddressDAL.Remove(userAddress);
            int result = await _uow.Complete();
            return ResultHelper<int>.ResultReturn(result);
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