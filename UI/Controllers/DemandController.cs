using System;
using System.IO;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Config;
using Entities.DTO.Demand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace UI.Controllers
{
    public class DemandController : Controller
    {
        private readonly IDemandService _demandService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly FileUploadSettings _fileUploadSettings;

        public DemandController(IDemandService demandService, IWebHostEnvironment webHostEnvironment, IOptions<FileUploadSettings> fileUploadSettings)
        {
            _demandService = demandService;
            _webHostEnvironment = webHostEnvironment;
            _fileUploadSettings = fileUploadSettings.Value;
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

            demandCreate.FilePath = Path.Combine(_webHostEnvironment.WebRootPath, _fileUploadSettings.PhotoPath);
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