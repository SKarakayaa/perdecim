using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
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
        public async Task<IActionResult> CreateOrUpdate(int? id = null)
        {
            UserAddressCreateUpdateDTO userAddress = new UserAddressCreateUpdateDTO();
            if (id != null)
                userAddress = await _userAddressService.GetUserAddressCreateUpdateDtoModel(id.Value);

            ViewBag.Cities = await _userAddressService.GetCityList();
            return View(userAddress);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate(UserAddressCreateUpdateDTO createUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cities = await _userAddressService.GetCityList();
                return View(nameof(CreateOrUpdate), createUpdateDTO);
            }
            IResult result = await _userAddressService.CreateOrUpdateAsync(createUpdateDTO);

            if (!result.IsSuccess)
            {
                ViewBag.Cities = await _userAddressService.GetCityList();
                ModelState.AddModelError("CreateError", result.Message);
                return View(nameof(CreateOrUpdate), createUpdateDTO);
            }
            return RedirectToAction(nameof(Addresses), "Address");
        }

        public async Task<JsonResult> Delete(int id)
        {
            IResult result = await _userAddressService.DeleteAsync(id);
            return Json(result);
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