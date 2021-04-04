using System;
using System.IO;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTO.Demand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class DemandController : Controller
    {
        private readonly IDemandService _demandService;
        public DemandController(IDemandService demandService)
        {
            _demandService = demandService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.DemandTypes = await _demandService.GetListAsync();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DemandTypeCreateOrUpdate(DemandTypeCreateDto demandTypeCreate)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DemandTypes = await _demandService.GetListAsync();
                return View("Index", new CreateDto { DemandTypeCreate = demandTypeCreate });
            }
            IResult result = await _demandService.CreateOrUpdateDemandTypeAsync(demandTypeCreate);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("SaveError", result.Message);
                ViewBag.DemandTypes = await _demandService.GetListAsync();
                return View("Index", new CreateDto { DemandTypeCreate = demandTypeCreate });
            }
            return RedirectToAction("Index", "Demand");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DemandCreate(DemandCreateDto demandCreate)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DemandTypes = await _demandService.GetListAsync();
                return View("Index", new CreateDto { DemandCreate = demandCreate });
            }

            IResult result = await _demandService.CreateDemandAsync(demandCreate);

            if (!result.IsSuccess)
            {
                ViewBag.DemandTypes = await _demandService.GetListAsync();
                ModelState.AddModelError("SaveError", result.Message);
                return View("Index", new CreateDto { DemandCreate = demandCreate });
            }
            return RedirectToAction("Index", "Demand");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDemand(int id)
        {
            IResult result = await _demandService.DeleteDemandAsync(id);
            return Json(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDemandType(int id)
        {
            IResult result = await _demandService.DeleteDemandTypeAsync(id);
            return Json(result);
        }
    }
}