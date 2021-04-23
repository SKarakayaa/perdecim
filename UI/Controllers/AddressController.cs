using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTO.Address;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IUserAddressService _userAddressService;

        public AddressController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }

        [HttpGet]
        public async Task<IActionResult> Addresses()
        {
            int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
            List<AddressViewDTO> addressViewDTO = await _userAddressService.GetListAsync(userId);
            return View(addressViewDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Cities = await _userAddressService.GetCityList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(UserAddressCreateUpdateDTO createUpdateDTO)
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetDistrictsByCityId(int cityId)
        {
            List<District> districts = await _userAddressService.GetDistrictListByCityIdAsync(cityId);
            return Json(districts);
        }
        [HttpPost]
        public async Task<JsonResult> GetNeighborhoodsByDistrictId(int districtId)
        {
            List<Neighborhood> neighborhoods = await _userAddressService.GetNeighborhoodListByDistrictIdAsync(districtId);
            return Json(neighborhoods);
        }
    }
}